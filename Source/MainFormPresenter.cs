//==============================================================
// Expert Installer
// Copyright © Miroslav Popov. All rights reserved.
//==============================================================
// THIS CODE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE.
//==============================================================

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using ExpertInstaller.Interfaces;

namespace ExpertInstaller
{
    public class MainFormPresenter : IMainFormPresenter
    {
        private const string ExpertName = "MT4-FST Expert.mq4";
        private const string ExpertEx4 = "MT4-FST Expert.ex4";
        private const string LibraryName = "MT4-FST Library.dll";

        private readonly List<string> ex4TargetList = new List<string>();
        private readonly List<string> expertTargetList = new List<string>();
        private readonly IIoManager ioManager;
        private readonly List<string> libraryTargetList = new List<string>();
        private readonly List<string> mqlcacheTargetList = new List<string>();
        private string expertSource;
        private string librarySource;
        private IMainForm view;

        public MainFormPresenter(IIoManager ioManager)
        {
            this.ioManager = ioManager;
            if (ioManager == null) throw new ArgumentNullException("ioManager");
        }

        public void CheckWorkingTerminals()
        {
            IEnumerable<Process> pnames = ioManager.GetRunningProcesses();
            var terminals = new List<string>();
            foreach (Process process in pnames)
                if (process.ProcessName == "terminal")
                    if (!terminals.Contains(process.MainWindowTitle))
                        terminals.Add(process.MainWindowTitle);

            view.ShowTermianlsWarning(terminals.ToArray());
        }

        public event EventHandler<EventArgs> CloseRequested;

        public void CloseClicked()
        {
            OnCloseRequested();
        }

        public void SetView(IMainForm mainForm)
        {
            view = mainForm;
        }

        public void InstallClicked()
        {
            if (!CheckSourceFiles())
                return;

            List<string> pathMql4Dirs = GetMql4Dirs();
            if (pathMql4Dirs.Count > 0)
                SetTargets(pathMql4Dirs);

            List<string> pathMql4Xp = GetMql4DirsXp();
            if (pathMql4Xp.Count > 0)
                SetTargets(pathMql4Xp);

            List<string> pathMql4X86 = GetMql4DirsX86();
            if (pathMql4X86.Count > 0)
                SetTargets(pathMql4X86);

            int count = pathMql4Dirs.Count + pathMql4Xp.Count + pathMql4X86.Count;

            if (count == 0)
            {
                view.AppendOutput("No Meta Trader terminals were found.\r\nPlease click \"Installation Help\" above.");
                view.AppendOutput(Environment.NewLine);
                return;
            }

            DeleteOldFiles();
            int files = CopyNewFiles();
            view.AppendOutput(files > 0 ? "Done!" : "Expert was not installed! Please click \"Installation Help\" above.");
        }

        private bool CheckSourceFiles()
        {
            expertSource = Path.Combine(ioManager.CurrentDirectory, ExpertName);
            librarySource = Path.Combine(ioManager.CurrentDirectory, LibraryName);

            if (!ioManager.FileExists(expertSource))
            {
                view.AppendOutput(string.Format("Could not find Expert file."));
                return false;
            }
            if (!ioManager.FileExists(librarySource))
            {
                view.AppendOutput(string.Format("Could not find Library file."));
                return false;
            }
            return true;
        }

        private List<string> GetMql4Dirs()
        {
            string pathAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string pathTerminals = Path.Combine(pathAppData, @"MetaQuotes\Terminal\");
            IEnumerable<string> baseDirs = ioManager.GetDirectories(pathTerminals);

            return baseDirs.Select(baseDir => Path.Combine(baseDir, "MQL4"))
                .Where(pathMql4 => ioManager.DirectoryExists(pathMql4)).ToList();
        }

        private List<string> GetMql4DirsXp()
        {
            string pathAppData = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            IEnumerable<string> baseDirs = ioManager.GetDirectories(pathAppData, "*", SearchOption.TopDirectoryOnly);
            return baseDirs.Select(baseDir => Path.Combine(baseDir, "MQL4"))
                .Where(pathMql4 => ioManager.DirectoryExists(pathMql4)).ToList();
        }

        private List<string> GetMql4DirsX86()
        {
            string pathAppData = ProgramFilesx86();
            IEnumerable<string> baseDirs = ioManager.GetDirectories(pathAppData, "*", SearchOption.TopDirectoryOnly);
            return baseDirs.Select(baseDir => Path.Combine(baseDir, "MQL4"))
                .Where(pathMql4 => ioManager.DirectoryExists(pathMql4)).ToList();
        }

        private void SetTargets(IEnumerable<string> pathMql4Dirs)
        {
            foreach (string mql4Dir in pathMql4Dirs)
            {
                expertTargetList.Add(Path.Combine(mql4Dir, @"Experts\" + ExpertName));
                ex4TargetList.Add(Path.Combine(mql4Dir, @"Experts\" + ExpertEx4));
                libraryTargetList.Add(Path.Combine(mql4Dir, @"Libraries\" + LibraryName));
                mqlcacheTargetList.Add(Path.Combine(mql4Dir, @"Experts\mqlcache.dat"));
                mqlcacheTargetList.Add(Path.Combine(mql4Dir, @"Libraries\mqlcache.dat"));
            }
        }

        private void DeleteOldFiles()
        {
            foreach (string path in expertTargetList)
                ioManager.DeleteFile(path);
            foreach (string path in ex4TargetList)
                ioManager.DeleteFile(path);
            foreach (string path in libraryTargetList)
                ioManager.DeleteFile(path);
            foreach (string path in mqlcacheTargetList)
                ioManager.DeleteFile(path);
        }

        private int CopyNewFiles()
        {
            int experts = expertTargetList.Count(expertTarget => ioManager.CopyFile(expertSource, expertTarget));
            int libs = libraryTargetList.Count(libraryTarget => ioManager.CopyFile(librarySource, libraryTarget));
            return experts + libs;
        }

        private static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size ||
                (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        protected virtual void OnCloseRequested()
        {
            EventHandler<EventArgs> handler = CloseRequested;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
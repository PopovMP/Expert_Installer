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
using BridgeInstaller.Interfaces;

namespace BridgeInstaller.Helpers
{
    public class IoManager : IIoManager
    {
        public string CurrentDirectory
        {
            get { return Environment.CurrentDirectory; }
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public string[] GetDirectories(string path)
        {
            try
            {
                return Directory.GetDirectories(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption)
        {
            return Directory.GetDirectories(path, searchPattern, searchOption);
        }

        public void VisitWebLink(string linkUrl)
        {
            try
            {
                Process.Start(linkUrl);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public IEnumerable<Process> GetRunningProcesses()
        {
            return Process.GetProcesses();
        }

        public bool DirectoryExists(string pathMql4)
        {
            return Directory.Exists(pathMql4);
        }

        public void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public bool CopyFile(string source, string target)
        {
            try
            {
                File.Copy(source, target);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            return false;
        }

        public string ReadText(string path)
        {
            try
            {
                return File.ReadAllText(path);
            }
            catch (Exception)
            {
                return String.Empty;
            }
        }
    }
}
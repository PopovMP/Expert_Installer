//==============================================================
// Expert Installer
// Copyright © Miroslav Popov. All rights reserved.
//==============================================================
// THIS CODE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE.
//==============================================================

using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace ExpertInstaller.Interfaces
{
    public interface IIoManager
    {
        string CurrentDirectory { get; }
        bool FileExists(string path);
        string[] GetDirectories(string path);
        string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        void RunFile(string path, string arguments);
        void VisitWebLink(string linkUrl);
        IEnumerable<Process> GetRunningProcesses();
        bool DirectoryExists(string pathMql4);
        void DeleteFile(string path);
        bool CopyFile(string source, string target);
    }
}
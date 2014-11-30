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

namespace BridgeInstaller.Interfaces
{
    public interface IMainFormPresenter
    {
        void SetView(IMainForm mainForm);
        void CheckWorkingTerminals();
        void InstallClicked();
        void ProcedeSilently();
        void CloseClicked();
        event EventHandler<EventArgs> CloseRequested;
    }
}
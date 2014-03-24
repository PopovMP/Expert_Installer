//==============================================================
// Forex Strategy Builder
// Copyright © Miroslav Popov. All rights reserved.
//==============================================================
// THIS CODE IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE.
//==============================================================

using System;
using System.Threading;
using System.Windows.Forms;
using ExpertInstaller.Helpers;
using ExpertInstaller.Interfaces;

namespace ExpertInstaller
{
    internal static class Program
    {
        private static readonly Mutex AppMutex = new Mutex(true, "{93c68028-462d-4062-b41d-c6b8b190671e}");
        private static IMainFormPresenter presenter;
        private static bool isClosedManaged;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            if (!AppMutex.WaitOne(TimeSpan.Zero, true)) return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new Container();
            container.Register<IMainForm, MainForm>().AsSingleton();
            container.Register<IMainFormPresenter, MainFormPresenter>().AsSingleton();
            container.Register<IIoManager, IoManager>().AsSingleton();

            presenter = container.Resolve<IMainFormPresenter>();
            presenter.CloseRequested += Presenter_CloseRequested;

            Application.Idle += Application_Idle;
            Application.Run(container.Resolve<IMainForm>() as Form);

            CloseApplication();
        }

        private static void Application_Idle(object sender, EventArgs e)
        {
            Application.Idle -= Application_Idle;
            presenter.CheckWorkingTerminals();
        }

        private static void Presenter_CloseRequested(object sender, EventArgs e)
        {
            CloseApplication();
        }

        private static void CloseApplication()
        {
            if (isClosedManaged) return;
            isClosedManaged = true;
            AppMutex.ReleaseMutex();
            Application.Exit();
        }
    }
}
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
using System.IO;
using System.Text;
using System.Windows.Forms;
using ExpertInstaller.Interfaces;

namespace ExpertInstaller
{
    public partial class MainForm : Form, IMainForm
    {
        private readonly IIoManager ioManager;
        private readonly IMainFormPresenter presenter;

        public MainForm(
            IMainFormPresenter presenter,
            IIoManager ioManager)
        {
            if (presenter == null) throw new ArgumentNullException("presenter");
            if (ioManager == null) throw new ArgumentNullException("ioManager");
            this.presenter = presenter;
            this.ioManager = ioManager;

            presenter.SetView(this);

            InitializeComponent();
        }

        public void AppendOutput(string text)
        {
            tbxOutput.AppendText(text);
        }

        public void ShowTermianlsWarning(string[] terminals)
        {
            if (terminals.Length == 0)
                return;

            var sb = new StringBuilder();
            foreach (string terminal in terminals)
                sb.AppendLine(terminal);

            string text = string.Format("Please close all MT4 instances before continue!\r\n\r\n{0}", sb);
            MessageBox.Show(text, "Expert Installer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Install_Click(object sender, EventArgs e)
        {
            presenter.InstallClicked();
        }

        /// <summary>
        ///     Close the form
        /// </summary>
        private void Close_Click(object sender, EventArgs e)
        {
            presenter.CloseClicked();
        }

        private void LinkMsRedist_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var control = (Control) sender;
            ioManager.VisitWebLink(control.Tag.ToString());
        }

        private void Help_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem) sender;
            ioManager.VisitWebLink(item.Tag.ToString());
        }

        private void Support_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem) sender;
            ioManager.VisitWebLink(item.Tag.ToString());
        }
    }
}
﻿using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using UniversalisCommon;
using UniversalisStandaloneUploader.Properties;

namespace UniversalisStandaloneUploader
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            if (UpdateUtils.CheckNeedsUpdate(Assembly.GetAssembly(typeof(Program))))
            {
                var dlgResult = MessageBox.Show(
                    Resources.UniversalisNeedsUpdateLong,
                    Resources.UniversalisNeedsUpdateLongCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                if (dlgResult == DialogResult.OK)
                {
                    UpdateUtils.OpenLatestReleaseInBrowser();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var uploaderForm = new UploaderForm();

            Application.Run();

            uploaderForm.ShowTrayIcon();
        }
    }
}

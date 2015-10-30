using PasswordGenerator.Properties;
using System;
using System.Windows.Forms;

namespace PasswordGenerator
{
    internal static class Program
    {
        public const string SaltFileName = @"salt.bin";
        public const int SaltByteCount = 64;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            AsyncTaskManager.OnApplicationExit();
        }

        public static void DisplayFileError()
        {
            AsyncTaskManager.RunInBackground(() =>
            {
                MessageBox.Show(Resources.FileError);
            });
        }
    }
}

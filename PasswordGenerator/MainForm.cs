using PasswordGenerator.Properties;
using System;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class MainForm : Form
    {
        private readonly byte[] mSalt = new byte[Program.SaltByteCount];
        private readonly SHA1 mSha1 = SHA1.Create();

        public MainForm()
        {
            InitializeComponent();
            SaltSettings.Text = Resources.Salt;
            DomainNameLabel.Text = Resources.DomainNameIs;
            PasswordLabel.Text = Resources.PasswordIs;
            CopyToClipboardButton.Text = Resources.CopyToClipboard;
            ShowPasswordCheckBox.Text = Resources.ShowPassword;
            HandleCreated += OnHandleCreated;
        }

        private void OnHandleCreated(object sender, EventArgs e)
        {
            Text = Resources.AppTitle;
            AsyncTaskManager.RunInBackground(ReadSaltFromFile);
        }

        private void SaltSettings_Click(object sender, EventArgs e)
        {
            LaunchSaltSettingsDialog();
        }

        private void LaunchSaltSettingsDialog()
        {
            using (SaltSettingsForm form = new SaltSettingsForm())
            {
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    AsyncTaskManager.RunInBackground(ReadSaltFromFile);
                }
            }
        }

        private void ReadSaltFromFile()
        {
            Invoke(new Action(() =>
            {
                Enabled = false;
            }));
            try
            {
                using (FileStream stream = new FileStream(
                    Program.SaltFileName,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    stream.Read(mSalt, 0, mSalt.Length);
                }
                BeginInvoke(new Action(UpdateHashResult));
            }
            catch (FileNotFoundException)
            {
                BeginInvoke(new Action(LaunchSaltSettingsDialog));
            }
            catch (IOException)
            {
                Program.DisplayFileError();
            }
            catch (SecurityException)
            {
                Program.DisplayFileError();
            }
            finally
            {
                BeginInvoke(new Action(() =>
                {
                    Enabled = true;
                }));
            }
        }

        private void UpdateHashResult()
        {
            byte[] input = Encoding.UTF8.GetBytes(DomainNameTextBox.Text);
            byte[] data = new byte[input.Length + mSalt.Length];
            Buffer.BlockCopy(input, 0, data, 0, input.Length);
            Buffer.BlockCopy(mSalt, 0, data, input.Length, mSalt.Length);
            byte[] hash = mSha1.ComputeHash(data);
            PasswordTextBox.Text = Convert.ToBase64String(hash).Substring(0, 14);
        }

        private void DomainNameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateHashResult();
        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !ShowPasswordCheckBox.Checked;
        }

        private void CopyToClipboardButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(PasswordTextBox.Text);
        }
    }
}

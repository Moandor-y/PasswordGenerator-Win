using PasswordGenerator.Properties;
using System;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace PasswordGenerator
{
    public partial class SaltSettingsForm : Form
    {
        private const int StringLength = Program.SaltByteCount * 2;
        private static readonly Random Random = new Random();

        public SaltSettingsForm()
        {
            InitializeComponent();
            HexSaltTextBox.MaxLength = StringLength;
            OkButton.Text = Resources.Ok;
            ButtonCancel.Text = Resources.Cancel;
            GenerateButton.Text = Resources.Generate;
            HandleCreated += OnHandleCreated;
        }

        private void OnHandleCreated(object sender, EventArgs e)
        {
            Text = Resources.SaltSettings;
            AsyncTaskManager.RunInBackground(ReadSaltFromFile);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            string hex = HexSaltTextBox.Text;
            StringBuilder builder = new StringBuilder(hex);
            if (hex.Length < StringLength)
            {
                builder.Append('0', StringLength - hex.Length);
            }
            else
            {
                builder.Remove(StringLength, hex.Length - StringLength);
            }
            AsyncTaskManager.RunInBackground(() => WriteSaltToFile(builder.ToString()));
            Enabled = false;
        }

        private void HexSaltTextBox_TextChanged(object sender, EventArgs e)
        {
            string text = HexSaltTextBox.Text;
            int selection = HexSaltTextBox.SelectionStart;
            int selectionLength = HexSaltTextBox.SelectionLength;
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                if (Uri.IsHexDigit(c))
                {
                    if (i == selection)
                    {
                        selection = builder.Length;
                    }
                    builder.Append(c);
                }
            }
            HexSaltTextBox.Text = builder.ToString();
            HexSaltTextBox.SelectionStart = selection;
            HexSaltTextBox.SelectionLength = Math.Min(selectionLength,
                Math.Max(HexSaltTextBox.Text.Length - selection, 0));
        }

        private void WriteSaltToFile(string hex)
        {
            try
            {
                byte[] data = Utilities.HexToBytes(hex);
                using (FileStream stream = new FileStream(
                    Program.SaltFileName,
                    FileMode.OpenOrCreate,
                    FileAccess.Write))
                {
                    stream.Seek(0, SeekOrigin.Begin);
                    stream.SetLength(data.Length);
                    stream.Write(data, 0, data.Length);
                }
                BeginInvoke(new Action(() =>
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }));
            }
            catch (IOException)
            {
                Program.DisplayFileError();
            }
            catch (SecurityException)
            {
                Program.DisplayFileError();
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
                    byte[] data = new byte[stream.Length];
                    stream.Read(data, 0, data.Length);
                    string hex = Utilities.BytesToHex(data);
                    BeginInvoke(new Action(() =>
                    {
                        HexSaltTextBox.Text = hex;
                    }));
                }
            }
            catch (FileNotFoundException)
            {
                // Do nothing
            }
            catch (IOException)
            {
                Program.DisplayFileError();
            }
            catch (SecurityException)
            {
                Program.DisplayFileError();
            }
            BeginInvoke(new Action(() =>
            {
                Enabled = true;
            }));
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[Program.SaltByteCount];
            Random.NextBytes(data);
            HexSaltTextBox.Text = Utilities.BytesToHex(data);
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

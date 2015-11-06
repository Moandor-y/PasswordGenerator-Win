namespace PasswordGenerator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.SaltSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.DomainNameTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.DomainNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.CopyToClipboardButton = new System.Windows.Forms.Button();
            this.ShowPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaltSettings});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(514, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "Main Menu";
            // 
            // SaltSettings
            // 
            this.SaltSettings.Name = "SaltSettings";
            this.SaltSettings.Size = new System.Drawing.Size(80, 20);
            this.SaltSettings.Text = "SaltSettings";
            this.SaltSettings.Click += new System.EventHandler(this.SaltSettings_Click);
            // 
            // DomainNameTextBox
            // 
            this.DomainNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DomainNameTextBox.Location = new System.Drawing.Point(115, 27);
            this.DomainNameTextBox.Name = "DomainNameTextBox";
            this.DomainNameTextBox.Size = new System.Drawing.Size(387, 26);
            this.DomainNameTextBox.TabIndex = 1;
            this.DomainNameTextBox.TextChanged += new System.EventHandler(this.DomainNameTextBox_TextChanged);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTextBox.Location = new System.Drawing.Point(115, 59);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.ReadOnly = true;
            this.PasswordTextBox.Size = new System.Drawing.Size(387, 26);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // DomainNameLabel
            // 
            this.DomainNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DomainNameLabel.AutoSize = true;
            this.DomainNameLabel.Location = new System.Drawing.Point(12, 34);
            this.DomainNameLabel.Name = "DomainNameLabel";
            this.DomainNameLabel.Size = new System.Drawing.Size(97, 13);
            this.DomainNameLabel.TabIndex = 3;
            this.DomainNameLabel.Text = "DomainNameLabel";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 65);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(79, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "PasswordLabel";
            // 
            // CopyToClipboardButton
            // 
            this.CopyToClipboardButton.Location = new System.Drawing.Point(15, 114);
            this.CopyToClipboardButton.Name = "CopyToClipboardButton";
            this.CopyToClipboardButton.Size = new System.Drawing.Size(487, 45);
            this.CopyToClipboardButton.TabIndex = 5;
            this.CopyToClipboardButton.Text = "CopyToClipboardButton";
            this.CopyToClipboardButton.UseVisualStyleBackColor = true;
            this.CopyToClipboardButton.Click += new System.EventHandler(this.CopyToClipboardButton_Click);
            // 
            // ShowPasswordCheckBox
            // 
            this.ShowPasswordCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowPasswordCheckBox.AutoSize = true;
            this.ShowPasswordCheckBox.Location = new System.Drawing.Point(354, 91);
            this.ShowPasswordCheckBox.Name = "ShowPasswordCheckBox";
            this.ShowPasswordCheckBox.Size = new System.Drawing.Size(148, 17);
            this.ShowPasswordCheckBox.TabIndex = 6;
            this.ShowPasswordCheckBox.Text = "ShowPasswordCheckBox";
            this.ShowPasswordCheckBox.UseVisualStyleBackColor = true;
            this.ShowPasswordCheckBox.CheckedChanged += new System.EventHandler(this.ShowPasswordCheckBox_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 171);
            this.Controls.Add(this.ShowPasswordCheckBox);
            this.Controls.Add(this.CopyToClipboardButton);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.DomainNameLabel);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.DomainNameTextBox);
            this.Controls.Add(this.MainMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "AppTitle";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem SaltSettings;
        private System.Windows.Forms.TextBox DomainNameTextBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label DomainNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button CopyToClipboardButton;
        private System.Windows.Forms.CheckBox ShowPasswordCheckBox;
    }
}


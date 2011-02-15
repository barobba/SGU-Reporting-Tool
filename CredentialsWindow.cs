using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    public partial class CredentialsWindow : Form
    {
        private SecureString _username = new SecureString();
        private SecureString _password = new SecureString();

        public CredentialsWindow()
        {
            InitializeComponent();

            _username.Clear();
            _password.Clear();
        }

        public SecureString Username
        {
            get { return _username; }
        }

        public SecureString Password
        {
            get { return _password; }
        }

        private void textBoxUsernamePassword_TextChanged(object sender, EventArgs e)
        {
            if (textBoxUsername.Text.Length > 0 && textBoxPassword.Text.Length > 0)
                buttonLogin.Enabled = true;
            else
                buttonLogin.Enabled = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            _username.Clear();
            for (int i = 0; i < textBoxUsername.Text.Length; ++i)
                _username.AppendChar(textBoxUsername.Text[i]);
            _username.MakeReadOnly();

            _password.Clear();
            for (int i = 0; i < textBoxPassword.Text.Length; ++i)
                _password.AppendChar(textBoxPassword.Text[i]);
            _password.MakeReadOnly();
            
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

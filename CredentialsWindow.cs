using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SGU_Reporting_Tool
{
    public partial class CredentialsWindow : Form
    {
        private string _username;
        private string _password;

        public CredentialsWindow()
        {
            InitializeComponent();

            _username = _password = "";
        }

        public string Username
        {
            get { return _username; }
        }
        
        public string Password
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
            _username = textBoxUsername.Text;
            _password = textBoxPassword.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

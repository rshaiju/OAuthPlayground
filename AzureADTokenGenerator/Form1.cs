using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AzureADTokenGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            var authority = string.Format("https://login.microsoftonline.com/{0}", textBoxTenant.Text);
            var authenticationContext = new AuthenticationContext(authority);

            var userCredentials = new UserCredential(textBoxUserName.Text, textBoxPwd.Text);

            textBoxToken.Text = "Bearer " + authenticationContext.AcquireToken(textBoxAppIdUri.Text, textBoxClientId.Text, userCredentials).AccessToken;

            Clipboard.SetText(textBoxToken.Text);
        }
    }
}

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

            //appId uri is the app id uri of the api app we want to access
            //client id is the app id of the native/client app. We cannot get a token directly for api using user credentials
            //the user gets the token for a native app that has permissions to access the web api app
            textBoxToken.Text = "Bearer " + authenticationContext.AcquireToken(textBoxAppIdUri.Text, textBoxClientId.Text, userCredentials).AccessToken;

            Clipboard.SetText(textBoxToken.Text);
        }
    }
}

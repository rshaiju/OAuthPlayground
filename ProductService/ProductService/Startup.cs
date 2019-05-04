using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using System.Configuration;

[assembly: OwinStartup(typeof(ProductService.Startup))]

namespace ProductService
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            string tenant = ConfigurationManager.AppSettings["ida:tenant"];
            string clientId= ConfigurationManager.AppSettings["ida:clientId"];

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(new WindowsAzureActiveDirectoryBearerAuthenticationOptions {
                Tenant= tenant,
                TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidAudience=clientId
                }
            });
        }
    }
}

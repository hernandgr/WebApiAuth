using Microsoft.Owin;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Configuration;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebApiAzureAD.Api.Startup))]

namespace WebApiAzureAD.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureAuth(app);

            WebApiConfig.Register(config);

            app.UseWebApi(config);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Audience = ConfigurationManager.AppSettings["Audience"],
                    Tenant = ConfigurationManager.AppSettings["Tenant"]
                });
        }
    }
}
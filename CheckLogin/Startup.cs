using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CheckLogin.Startup))]
namespace CheckLogin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}

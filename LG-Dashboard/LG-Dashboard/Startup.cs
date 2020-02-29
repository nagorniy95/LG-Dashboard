using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LG_Dashboard.Startup))]
namespace LG_Dashboard
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

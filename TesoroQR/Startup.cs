using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesoroQR.Startup))]
namespace TesoroQR
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

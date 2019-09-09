using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CotizadorMVC.Startup))]
namespace CotizadorMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

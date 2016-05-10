using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Otelwebsitesi.Startup))]
namespace Otelwebsitesi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

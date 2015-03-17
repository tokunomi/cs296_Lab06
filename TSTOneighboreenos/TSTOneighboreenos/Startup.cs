using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TSTOneighboreenos.Startup))]
namespace TSTOneighboreenos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

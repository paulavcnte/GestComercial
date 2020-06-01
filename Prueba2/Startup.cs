using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Prueba2.Startup))]
namespace Prueba2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

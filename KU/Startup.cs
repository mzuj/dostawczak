using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KU.Startup))]
namespace KU
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRPZ_VOLSWAGEN.Startup))]
namespace TRPZ_VOLSWAGEN
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

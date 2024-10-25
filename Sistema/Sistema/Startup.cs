using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sistema.Startup))]
namespace Sistema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

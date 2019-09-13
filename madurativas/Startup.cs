using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(madurativas.Startup))]
namespace madurativas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

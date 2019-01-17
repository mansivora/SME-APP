using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(API1._0.Startup))]
namespace API1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

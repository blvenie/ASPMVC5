using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPMVC5.Startup))]
namespace ASPMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

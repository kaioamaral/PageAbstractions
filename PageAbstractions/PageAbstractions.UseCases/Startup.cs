using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PageAbstractions.UseCases.Startup))]
namespace PageAbstractions.UseCases
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

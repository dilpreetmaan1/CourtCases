using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourtCases.Startup))]
namespace CourtCases
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

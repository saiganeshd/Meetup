using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Meetup.Startup))]
namespace Meetup
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

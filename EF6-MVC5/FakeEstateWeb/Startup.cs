using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FakeEstateWeb.Startup))]
namespace FakeEstateWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}







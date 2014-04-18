using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(kudogen.Startup))]
namespace kudogen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

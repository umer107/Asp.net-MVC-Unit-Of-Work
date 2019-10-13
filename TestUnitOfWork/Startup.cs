using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestUnitOfWork.Startup))]
namespace TestUnitOfWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

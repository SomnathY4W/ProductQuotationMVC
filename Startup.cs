using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductQuotationMVC.Startup))]
namespace ProductQuotationMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

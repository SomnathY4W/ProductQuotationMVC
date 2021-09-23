using ProductQuotationMVC.Abstract;
using ProductQuotationMVC.Interfaces;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace ProductQuotationMVC
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            container.RegisterType<IProductBL, ProductBL>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
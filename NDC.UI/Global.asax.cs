﻿
namespace NDC.UI
{
    using Infrastructure;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //register area
            AreaRegistration.RegisterAllAreas();

            //filters
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //routes
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //resource bundlers
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //db migration
            ApplicationDbContext.Initializer();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //调用容器的创建
            var container = BlogContainer.GetContainer();
            //解析器的替换
            //DependencyResolver.SetResolver(new BlogDependencyResolver(container));
            //直接跳过IControllerActivator直接从容器创建
            ControllerBuilder.Current.SetControllerFactory(new BlogControllerFactory(container));
        }

         //注册事件
        //protected void Application_BeginRequest()
        //{
        //    this.Context.Response.Write("Application_BeginRequest <br/>");
        //}

        //protected void Application_EndRequest()
        //{
        //    this.Context.Response.Write("Application_EndRequest <br/>");
        //}
    }
}

using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Blog
{
    public class BlogControllerFactory : DefaultControllerFactory
    {
        private readonly ILifetimeScope _container;

        public BlogControllerFactory(ILifetimeScope container)
        {
            _container = container;
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            try
            {
              return (IController)_container.Resolve(controllerType);
            }
            catch
            {

            }
            return base.GetControllerInstance(requestContext, controllerType);
        }
    }
}
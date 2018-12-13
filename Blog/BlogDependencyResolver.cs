using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog
{
    public class BlogDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope _container;

        public BlogDependencyResolver(ILifetimeScope container)
        {
            _container = container;
        }
        public object GetService(Type serviceType)
        {
            try
            {
                var instance = _container.Resolve(serviceType);
                return instance;
            }
            catch
            {
                return null;
            }
            
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                var enumerableServiceType = typeof(IEnumerable<>).MakeGenericType(serviceType);
                var instance = _container.Resolve(enumerableServiceType);
                return (IEnumerable<object>)instance;
            }
            catch
            {
                return null;
            }
            
        }
    }
}
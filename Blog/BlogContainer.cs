using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using BlogBusinessLogic;
using Blog.Controllers;

namespace Blog
{
    public static class  BlogContainer
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<BlogManager>();
            builder.RegisterType<PostController>();
            builder.RegisterType<HomeController>();

            var container = builder.Build();
            return container;
        }
    }
}
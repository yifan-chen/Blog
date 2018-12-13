using Blog.Models;
using BlogBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{

    public class HomeController : Controller
    {
        private BlogManager manager;

        public HomeController(BlogManager blogManager)
        {
            manager = blogManager;
        }
        public ActionResult Index()
        {
            var posts = manager.GetTop5().Select(post => new PostViewModel()
            {
                Author = post.Author,
                Content = post.Content,
                CreateDate = post.CreateDate,
                ID = post.ID,
                ModifyDate = post.ModifyDate,
                Title = post.Title
            }).ToList();
            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "本博客用于分享ASP.NET知识.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "联系方式";

            return View();
        }

        public ActionResult Event()
        {
            return Content("ProcessRequest Event <br/>");
        }
    }
}
using Blog.Models;
using BlogModel;
using BlogBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private BlogManager manager;

        public PostController(BlogManager blogManager)
        {
            manager = blogManager;
        }

        /// <summary>
        /// 获取文章的列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var posts = manager.GetAllPosts().Select(post => new PostViewModel()
            {
                Author = post.Author,
                Content = post.Content,
                CreateDate = post.CreateDate,
                ID = post.ID,
                ModifyDate = post.ModifyDate,
                Title = post.Title
            }).ToList();
            var postListViewModel = new PostListViewModel()
            {
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
                Posts = posts
            };

            return View(postListViewModel);
        }

        /// <summary>
        /// 获取文章内容
        /// </summary>
        /// <returns></returns>
        public ActionResult Get(int id)
        {
            var post = manager.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            var postViewModel = new PostViewModel()
            {
                Author = post.Author,
                Content = post.Content,
                CreateDate = post.CreateDate,
                ID = post.ID,
                ModifyDate = post.ModifyDate,
                Title = post.Title
            };
            return View(postViewModel);
        }

       


    }
}
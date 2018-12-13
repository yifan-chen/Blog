using Blog.Areas.Admin.Models;
using BlogBusinessLogic;
using BlogModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Controllers
{
    public class PostManagementController : Controller
    {
        private BlogManager manager = new BlogManager();
        // GET: Admin/PostManagement
        public ActionResult Index()
        {
            var posts = manager.GetAllPosts().Select(post => new PostMaintainViewModel()
            {
                Content = post.Content,
                ID = post.ID,
                Title = post.Title
            }).ToList();
            var postListViewModel = new PostMaintainListViewModel()
            {
                Count = posts.Count,
                PageCount = 1,
                Pages = 1,
                Posts = posts
            };

            return View(postListViewModel);
        }
        public ActionResult Update(int id)
        {
            var post = manager.GetPostById(id);
            if (post == null)
                return HttpNotFound();
            var postViewModel = new PostMaintainViewModel()
            {
                Content = post.Content,
                ID = post.ID,
                Title = post.Title
            };
            return View(postViewModel);
        }

        [HttpPost]
        public ActionResult Update(PostMaintainViewModel postModel)
        {
            var post = manager.GetPostById(postModel.ID);
            post.Content = postModel.Content;
            post.Title = postModel.Title;
            post.ModifyDate = DateTime.Now;
            manager.UpdatePost(post);
            return RedirectToAction("Index");
        }

        public ActionResult Insert()
        {
            var postViewModel = new PostMaintainViewModel();
            return View(postViewModel);
        }

        [HttpPost]
        public ActionResult Insert(PostMaintainViewModel postModel)
        {
            var post = new Post()
            {
                Title = postModel.Title,
                Content = postModel.Content,
                Author = "Bug收割机",
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                IsPublish = true
            };
            manager.Insert(post);
            return RedirectToAction("Index");
        }
    }
}
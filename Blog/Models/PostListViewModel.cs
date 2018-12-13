using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class PostListViewModel
    {
        public List<PostViewModel> Posts { get; set; }

        public int Count { get; set; }

        public int Pages { get; set; }

        public int PageCount { get; set; }
    }
}
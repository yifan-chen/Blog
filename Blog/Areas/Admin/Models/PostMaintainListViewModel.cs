using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Areas.Admin.Models
{
    public class PostMaintainListViewModel
    {
        public List<PostMaintainViewModel> Posts { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public int PageCount { get; set; }
    }
}
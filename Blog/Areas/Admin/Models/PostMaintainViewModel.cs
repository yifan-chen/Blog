using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Areas.Admin.Models
{
    public class PostMaintainViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }

       [AllowHtml]
        public string Content { get; set; }
    }

   
}
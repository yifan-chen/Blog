using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogModel
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public string Author { get; set; }
        public bool IsPublish { get; set; }
        public int ClickCount { get; set; }
    }
}
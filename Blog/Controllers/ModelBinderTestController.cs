using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class SimplyObject
    {
        [MaxLength(10)]
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }

    public class SimplyObject1
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public SimplyObject[] SimplyObjects { get; set; }
    }

    public class ModelBinderTestController : Controller
    {
        // GET: ModelBinderTest
        public ActionResult Demo1(string field)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        // GET: ModelBinderTest
        public ActionResult Demo2([Display(Name = "测试")][MaxLength(6)]string field)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        // GET: ModelBinderTest
        public ActionResult Demo3(string id)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }

        // GET: ModelBinderTest
        public ActionResult Demo4(SimplyObject obj, SimplyObject obj1 = null)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }


        // GET: ModelBinderTest
        public ActionResult Demo5(string[] fields)
        {
            return View();
        }

        // GET: ModelBinderTest
        public ActionResult Demo6(SimplyObject[] objs)
        {
            return View();
        }

        // GET: ModelBinderTest
        public ActionResult Demo7(Dictionary<string, SimplyObject> objs)
        {
            return View();
        }

        public ActionResult Demo8(SimplyObject1 obj)
        {
            return View();
        }

        public ActionResult Demo9(SimplyObject obj)
        {
            return View();
        }

        public ActionResult Demo10([Bind(Prefix = "a", Exclude = "Field1", Include ="Field2")]SimplyObject obj)
        {
            return View();
        }
    }
}
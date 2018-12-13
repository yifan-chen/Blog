using System.Web;
using System.Web.Optimization;

namespace Blog
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        { 
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                      "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryvalex").Include(
                        "~/Scripts/myblog.validate.extension.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/cleanblog/bootstrapcss").Include(
                      "~/Content/clean_blog/vendor/bootstrap/css/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/bundles/cleanblog/fonts").Include(
                      "~/Content/clean_blog/vendor/font-awesome/css/font-awesome.min.css",
                      new CssRewriteUrlTransform()));

            var cleanBlogStyleBundle = new StyleBundle("~/bundles/cleanblog/css").Include(
                     "~/Content/clean_blog/css/clean-blog.min.css",
                     new SampleTransform());
            cleanBlogStyleBundle.Transforms.Add(new SampleBundleTransform());
            bundles.Add(cleanBlogStyleBundle);

            bundles.UseCdn = true;
            var jqueryCDNPath = "https://cdn.bootcss.com/jquery/3.3.1/jquery.min.js";
            var jqueryBundle = new ScriptBundle("~/bundles/cleanblog/jquery", jqueryCDNPath).Include(
                "~/Content/clean_blog/vendor/jquery/jquery.js");
            jqueryBundle.CdnFallbackExpression = "window.jQuery";
            bundles.Add(jqueryBundle);

            bundles.Add(new ScriptBundle("~/bundles/cleanblog/bootstrapjs").Include(
                     "~/Content/clean_blog/vendor/bootstrap/js/*.js"));

            bundles.Add(new ScriptBundle("~/bundles/cleanblog/js").Include(
                     "~/Content/clean_blog/js/*.js"));

            BundleTable.EnableOptimizations = true;
        }


        public class SampleTransform : IItemTransform
        {
            public string Process(string includedVirtualPath, string input)
            {
                input += ".test {color: red;}";
                return input;
            }
        }

        public class SampleBundleTransform : IBundleTransform
        {
            public void Process(BundleContext context, BundleResponse response)
            {
                response.Content += @"/*hello selim*/";
            }
        }
    }
}

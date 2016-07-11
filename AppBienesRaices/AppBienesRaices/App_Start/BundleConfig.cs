using System.Web;
using System.Web.Optimization;

namespace AppBienesRaices
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/js/jquery-1.10.2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Content/bootstrap/js/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/siteCss").Include("~/Content/bootstrap/css/bootstrap.min.css",
                    "~/Content/css/local.css",
                    "~/Content/font-awesome/css/font-awesome.min.css"));
        }
    }
}

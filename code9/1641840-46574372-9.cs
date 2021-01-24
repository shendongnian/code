    routes.MapRoute(
        name: "Area-CatchAll",
        url: "{area}",
        defaults: new { controller = "Area", action = "Translate" }
    );
    public class AreaController : Controller
    {
        // The {area} from route template will be mapped to this area parameter.
        // The location query string will be mapped to this location parameter.
        public ActionResult Translate(string area, string location)
        {
            // This also assumes you have defined "index" method and
            // "dashboard" controller in each area.
            if (String.IsNullOrEmpty(location))
            {
                location = "dashboard";
            }
            return RedirectToAction("index", location, new { area = area });
        }
    }

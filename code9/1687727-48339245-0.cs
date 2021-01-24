    public class ResourceController : Controller
    {
        public ActionResult Css([Required]string filename)
        {
            return new FileStreamResult(Assembly.GetExecutingAssembly().GetManifestResourceStream("Defalut.Namespace.javascript." + filename), "text/javascript");
        }
        public ActionResult Js([Required]string filename)
        {
            return new FileStreamResult(Assembly.GetExecutingAssembly().GetManifestResourceStream("Defalut.Namespace.css." + filename), "text/css");
        }
    }

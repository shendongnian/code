    public class TestController : Controller {
    
        [HttpPost]
        public string Upload() {
            Logger.Debug("Upload Called, Request.Files.Count: " + System.Web.HttpContext.Current.Request.Files.Count);
    
            if(System.Web.HttpContext.Current.Request.Files.Count > 0)
                Logger.Debug("Okay");
            else
                Logger.Debug("Invalid file");
    
            return "done";
        }
    }

    public class ExampleController : Controller {
        public string GetContent() {
           return Url.Content("~/Path/To/File");
        }
    }

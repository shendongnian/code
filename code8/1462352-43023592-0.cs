    public class SomeControllerController : Controller {
        public IActionResult Index() {
            if (base.RouteData.Values.ContainsKey("mymodel") == false) {
                return NotFound();
            }
            MyModel model = (MyModel) base.RouteData.Values["mymodel"];
            //LOGIC...
            return Index(model);
        }
    }

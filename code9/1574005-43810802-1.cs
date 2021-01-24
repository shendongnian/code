    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Test() {
            Debug.WriteLine("Test was loaded");
            var instance = new Manager();
            var client = await instance.StartMyTask();
            var msg = "Caption: " + client.Description.Captions[0].Text;
            Debug.WriteLine(msg);
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }

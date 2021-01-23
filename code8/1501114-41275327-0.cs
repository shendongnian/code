    public class HomeController : Controller {
        private InstagramService IGService = new InstagramService();
        public async Task<ActionResult> About() {
           var model = await IGService.GetInstagramUser();
           return View(model);
        }
    }

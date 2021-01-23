        [HttpGet]
        public ActionResult CompAndMon()
        {
            var viewModel = new ViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult CompAndMon(PostModel model)
        {
            var viewModel = new ViewModel
            {
                Thing = model.Thing
            };
            return View(viewModel)
        }
        public class PostModel
        {
            public object Thing { get; set; }
        }
    
        public class ViewModel
        {
            public object Thing {get; set; }
        }

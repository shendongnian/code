    class HomeController : Controller {
        private IPersonModelService service;
        public HomeController(IPersonModelService service) {
            this.service = service;
        }
        [HttpGet]
        public ActionResult Index(PersonModel model) {
            if (model.SelectionSubmitted && !ValidateSelections(model)) {
                model.ShowValidationSummary = true;
            }
            return View("Index", service.Get(model));
        }
        private bool ValidateSelections(PersonModel model) {
            if (model.Name == "") {
                ModelState.AddModelError("EmptyPersonName", "Person name cannot be null");
            }
            return ModelState.IsValid;
        }
    }
	

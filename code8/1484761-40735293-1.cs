      public class TestController : Controller
    {
        // GET: Test
        public ActionResult Edit(string modelType)
        {
            if (modelType == "1") return View(new Models.TestViewModel1() {ModelType = "1"});
            if (modelType == "2") return View(new Models.TestViewModel2() {ModelType = "2" });
            return View(new Models.TestViewModel() { ModelType = "" });
        }
        [HttpPost]
        public ActionResult Edit(Models.TestViewModel model)
        {
            if (model.Prop1 == null) ModelState.AddModelError("Prop1", "Please type something");
            if (ModelState.IsValid) return RedirectToAction("Edit");
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit1(Models.TestViewModel1 model)
        {
            if (model.Prop1 == null || !model.Prop1.Contains("1")) ModelState.AddModelError("Prop1", "Please type at least one character 1");
            if (ModelState.IsValid) return RedirectToAction("Edit", new { modelType = "1" });
            return View("Edit", model);
        }
        [HttpPost]
        public ActionResult Edit2(Models.TestViewModel2 model)
        {
            if (model.Prop2 == null || !model.Prop1.Contains("2")) ModelState.AddModelError("Prop2", "Please type at least one character 2");
            if (ModelState.IsValid) return RedirectToAction("Edit", new { modelType = "2"});
            return View("Edit", model);
        }
    }

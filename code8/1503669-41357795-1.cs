        [ActionFilter]
        public ActionResult SomeView()
        {
            var someview = "SomeView";
            var somemodel = default(object);
            return View(someview, somemodel);
        }

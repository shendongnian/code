        [ActionFilter(ViewName = "SomeView")]
        public ActionResult SomeView()
        {
            //var someview = "SomeView";
            var somemodel = default(object);
            return View(somemodel);
        }

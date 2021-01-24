        public ActionResult Index()
        {
            //load up available tags and pass them to view
            ViewBag.Tags = new TagModel { AvailableTags = GetTags() };
            return View();
        }
        [HttpPost]
        public ActionResult Index(TagModel mod)
        {
            if (ModelState.IsValid)
            {
                //mod.SelectedTags contains your data.... do something 
                return RedirectToAction("Weeeeeeeee");
            }
            ViewBag.Tags = new TagModel { AvailableTags = GetTags() };
            return View();
        }

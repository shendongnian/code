        public ActionResult Index()
        {
            whateverModel d = new whateverModel();
            return View(d);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(whateverModel m)
        {
            
            if (ModelState.IsValid)
            {
		
               //its valid, update your database or do soemthing useful here
               return RedirectToAction("Success");
            }
            //its not valid reload the page and let data annotations show the error
            return View(m);
        }

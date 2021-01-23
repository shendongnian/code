        public async Task<ActionResult> Index()
        {
            ViewBag.Title = DateTime.Now.ToLongTimeString();
            await AsynchMethod();
            ViewBag.Title += "  -  " + DateTime.Now.ToLongTimeString();
            return View();
        }

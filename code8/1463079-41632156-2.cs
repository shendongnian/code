        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = "Administrators")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            return View();
        }
        [Authorize(Policy = "Name")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }

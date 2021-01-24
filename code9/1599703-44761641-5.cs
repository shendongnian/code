    [Authorize]
        [Authorize(Policy = "ReplaceHeader")]
        public IActionResult Index()
        {
            return View();
        }

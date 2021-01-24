    public IActionResult AddPayments()
        {
            try
            {
                ... // Omitted
    
                return RedirectToAction("Index", "Home", new { message = "Has successfully created payments today.");
            }
            catch (Exception)
            {    
                throw;
            }
        }
    
        public IActionResult Index(String message)
        {
            return View((Object) message);
        }

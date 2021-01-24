    public IActionResult Index()
    {
        // GO TO THE DATABASE!
        // GET SOME MODELS (STUFF)
        var s = new Seat() { Location = "Orchestra" , Price = 300.00 };
        return View(s);
    }

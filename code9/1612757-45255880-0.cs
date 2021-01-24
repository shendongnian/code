    public ActionResult GetBalance()
    {
        return View();
    }
    [HttpPost]
    public ActionResult GetBalance(string cardNumber)
    {
        // Do stuff to retrieve the balance here
        return View("GetBalance");
    }

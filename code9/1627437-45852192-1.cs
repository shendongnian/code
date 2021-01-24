    public IActionResult Charge(string stripeEmail, string stripeToken)
    {
        TempData["Price"] = Price;
        TempData["Description"] = Description;
        if (StripeHelpers.ChargeCustomer(stripeEmail, stripeToken, Price, Description))
            return RedirectToAction("Success");
        return RedirectToAction("Failure");
    }
    
    public IActionResult Success()
    {
        return View();
    }
    
    public IActionResult Failure()
    {
        return View();
    }

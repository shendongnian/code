       private void ReturnPriceAndDescription()
        {
           ViewData["Price"] = Price;
           ViewData["Description"] = Description;
        }
        
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            ReturnPriceAndDescription();
            if (StripeHelpers.ChargeCustomer(stripeEmail, stripeToken, Price, Description))
                return RedirectToAction("Success");
            return RedirectToAction("Failure");
        }
        
        public IActionResult Success()
        {
            ReturnPriceAndDescription();
            return View();
        }
        
        public IActionResult Failure()
        {
            ReturnPriceAndDescription();
            return View();
        }

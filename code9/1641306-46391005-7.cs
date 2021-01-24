    public IActionResult Success(string token)
    {
        var paymentMade = _context.Payments.SingleOrDefaultAsync(m => m.StripeToken == token).Result;
    
        if (paymentMade == null)
        {
            return NotFound();
        }
    
        return View();
    }

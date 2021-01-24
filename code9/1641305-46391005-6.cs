    public async Task<IActionResult> Success(string token)
    {
        var paymentMade = await _context.Payments.SingleOrDefaultAsync(m => m.StripeToken == token);
    
        if (paymentMade == null)
        {
            return NotFound();
        }
    
        return View();
    }

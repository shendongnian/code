    public async Task<IActionResult> PayTransactions()
    {
      
        ...
    
        return Json(new { paymentID = paypalPayment.PaymentId });
    }

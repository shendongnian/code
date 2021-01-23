    [HttpPost]
    public ActionResult Pay(Payments payment )
    {
        if(ModelState.IsValid)
        {
            payment.TransactionDate = DateTime.Now.ToUniversalTime();
            DB.Payment.Add(payment);
            DB.SaveChanges();

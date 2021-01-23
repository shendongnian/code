    [HttpPost]
    public ActionResult Pay(Payments payment )
    {
        var d=DateTime.Now.ToUniversalTime();
        if(ModelState.IsValid)
        {
               
            Payments p=new() Payments{
           AccountNumber=p.AccountNumber,
          Amount=payment.Amount,
         TransactionDate=d
    };
           
            DB.Payment.Add(p);
            DB.SaveChanges();

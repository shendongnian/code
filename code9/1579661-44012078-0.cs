    //APIHelper.cs
    public PaymentResult { get; private set; }
    // inside method
    PaymentResult = MakePayment(Order);
    if (PaymentResult == true)
     {
         //billing logic
     }
     else
     {
         return false;
     }    

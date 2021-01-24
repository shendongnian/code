    var service = new StripeChargeService(newgenSecretKey);
    var result;
    try
    {
     result = service.Create(newCharge);
    if (result.Paid)
    {
        lab.Text = "It worked";
        CartOrders.UpdateTransactionID(result.Id, OrderID, "Express Checkout");
        Response.Redirect("PgeCustSuccess.aspx?OrderID=" + OrderID);
      }
    }
    catch (StripeException stripeException)
    {
        Debug.WriteLine(stripeException.Message);
        stripe.Text = stripeException.Message;
        //CartOrders.UpdateTransactionID(result.FailureMessage, OrderID, "Express Checkout");    
    }

    public ActionResult Checkout(int? unum)
    {            
        if(unum!=null)
        {
          var allOrders = db.Orders.Where(o =>  o.OrderNum==unum.Value);
          foreach(var order in allOrders)
          {
             order.RecievedShirt = false;
             order.OrderCompleted = true;
          }
          db.SaveChanges();
        }
        //to do : Do something if unum is null ????? 
        var AuthenticationManager = HttpContext.GetOwinContext().Authentication;
        AuthenticationManager.SignOut();
        return RedirectToAction("Purchased", "Orders");        
    }

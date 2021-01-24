    string clientIdStr = Context.User.Identity.GetUserId();
    if (!String.IsNullOrEmpty(clientIdStr ))
    {
      //your existing code to get other values
      if (Int32.TryParse(clientIdStr , out int clientId))
       {
            //use clientId now 
            var cart = new Cart
            {
                Amount = amount,
                ClientID = clientId,
                Date = DateTime.Now,
                IsInCart = true,
                ProductID = id
            };          
       }
    }

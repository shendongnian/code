    public Class Cart
    {
      public int BookId {get; set;}
      public string Title {get; set;}
      public int Qty {get; set;}
      public decimal Price {get; set}
    }
    
    List<Cart> carts =Session["Cart"]==null? new List<Cart>(): Session["Cart"] as List<Cart>;
    var existingCart = carts.Where(x=> x.BookId==newBookId).FirstOrDefault();
    if(existingCart==null)
    {
      Cart c= new Cart {
      BookId = newBookId,
      Title =newTitle,
      Qty = newQty,
      Price =newPrice
    };
     carts.Add(c);
     Session["Cart"] = carts;
    }

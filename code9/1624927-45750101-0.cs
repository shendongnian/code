    String[] carts = Request.Cookies["ShoppingCart"].Value.Split("|")
    bool bookIdExists = false;
    foreach(string cartDetail in carts)
    {
      string  bookId = cartDetail.Split(",")[0];
      if(bookId == newBookId)
      {
        bookIdExists = true;
      }
    }
    if(!bookIDExists)
    {
      //Add your new item to Cookie
    }

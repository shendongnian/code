      //You should set the value of productId and userId first
      // Assuming _db.Products is your DbSet<Product> property in the DbContext class
      var fav = _db.Products.FirstOrDefault(x => x.ProductId = productId && x.UserId == userId);
      if(fav == null){
      //That mean you should add the element
        _db.Products.Add(fav);
      }
      else{
        _db.Products.Remove(fav);
      }
      _db.SaveChanges();

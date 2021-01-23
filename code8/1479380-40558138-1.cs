	public ActionResult AddToCart(int productId)
	{
		// get a cart from session or create new
		var cart = Session["cart"] as List<CartVM> ?? new List<CartVM>();
		
		using(var db = new Db())
		{
			// get product in question
			var product = db.Products
				.FirstOrDefault(x => x.Id == productId)
		
            // if this is unknown product, throw exception
            if(product == null)
            {
                thrown new ArgumentException("Invalid product", nameof(productId));
            }
			// get existing line
			var existingCartLine = cart
				.FirstOrDefault(x => x.ProductId == productId);
			
			// if there was no existing line, add a new one
			if(existingCartLine == null)
			{
				cart.Add(new CartVM
				{
					ProductId = product.Id,
					Quantity = 1,
					Price = product.Price,
					TotalPrice = product.Price
				});
			}
			else
			{
				// otherwise modify existing line
				existingCartLine.Quantity++;
				existingCartLine.TotalPrice = cartLine.Price * cartLine.Quantity;
			}
		}
		
		// save cart back in the session
		Session["cart"] = cart;
		
		// return view
		return PartialView(cart);
	}

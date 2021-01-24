    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        var addToCartButton = (Button)sender;
        // notice I donn't call .ToString() below
        // because Button.CommandArgument is already a string
        var productId = addToCartButton.CommandArgument;   	   	  	
    	var cart = GetShoppingCartFromCookie();
        if(cart.Items.ContainsKey(productId)
    	{
            //their cart already contained this product, so let's bump the quantity
            cart.Items[productId].Quantity += 1;
        }
    	else
    	{
    		//their cart didn't contain this product, so we'll add it
            var cartItem = new CartItem { ProductId = productId, Quantity = 1 };
    		cart.Items.Add(cartItem.ProductId, cartItem);    						
    	}
        SaveShoppingCartToCookie(cart);
    }
    
    private void SaveShoppingCartToCookie(Cart cart)
    {
        var cartJson = JsonConvert.SerializeObject(cart); //using Newtonsoft.Json
        Response.Cookies[ShoppingCartCookieName].Value = cartJson;
        Response.Cookies[ShoppingCartCookieName].Expires = DateTime.Now.AddHours(1);
    }
    private Cart GetShoppingCartFromCookie()
    {
        if (Request.Cookies[ShoppingCartCookieName] == null)
        {
             return new Cart();
        }
        else
        {
            var existingCartJson = Response.Cookies[ShoppingCartCookieName].Value;
            // you may wish for some logic here to make sure the JSON can be converted
            // to a Cart since a user could have modified the cookie value.
    		var cart = JsonConvert.DeserializeObject<Cart>(existingCartJson);            
            return cart;
        }
    }

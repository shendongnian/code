    protected void btnAddtoCart_Click(object sender, EventArgs e)
    {
        Button addToCartButton = (Button)sender;
        string productId = addToCartButton.CommandArgument; //notice I didn't call .ToString() because Button.CommandArgument is already a string
    	var productRepository = new ProductRepository(ConfigurationManager.ConnectionStrings["ProductsDatabase"].ConnectionString);
    	var product = productRepository.GetProductById(productId);
    	var cartItem = new CartItem() { ProductId = product.Id, Quantity = 1 };  	
    	
    	if (Request.Cookies[ShoppingCartCookieName] == null)
        {
    	    //the user didn't have a shopping cart cookie, so we'll create one for them
    	    var cart = new Cart();
    		cart.Items.Add(cartItem.ProductId, cartItem);
    		SaveShoppingCartToCookie(cart);
        }
    	else
    	{
    	    var existingCartJson = Response.Cookies[ShoppingCartCookieName].Value;
    		var cart = JsonConvert.DeserializeObject<Cart>(existingCartJson);
    		
    		if(cart.Items.ContainsKey(cartItem.ProductId)
    		{
    		    //their cart already contained this product, so let's bump the quantity
    		    cart.Items[cartItem.ProductId].Quantity += 1;
    			SaveShoppingCartToCookie(cart);
    		}
    		else
    		{
    		    //their cart didn't contain this product, so we'll add it
    			cart.Items.Add(cartItem.ProductId, cartItem);
    			SaveShoppingCartToCookie(cart);
    		}				
    	}
    }
    
    private void SaveShoppingCartToCookie(Cart cart)
    {
        var cartJson = JsonConvert.SerializeObject(cart); //using Newtonsoft.Json
        Response.Cookies[ShoppingCartCookieName].Value = cartJson;
        Response.Cookies[ShoppingCartCookieName].Expires = DateTime.Now.AddHours(1);
    }

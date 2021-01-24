    public void SaveCart2Cookie(List<string> items) 
    {
    	string cartList = string.Join(",", items);
    
    	if (Request.Cookies["CartCookie"] == null)
    		Response.Cookies["CartCookie"].Value = cartList;
    	else
    	{
    		Create new Cart Cookie
    	}
    
    	Response.Cookies["CartCookie"].Expires = DateTime.Now.AddHours(24);
    }

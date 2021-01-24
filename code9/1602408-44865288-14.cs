    public class CartItem
    {
        public string ProductId { get; set; }
    	
    	public int Quantity {get; set; }
    }
    
    public class Cart
    {
        public Dictionary<string, CartItem> Items { get; set; }
    	
    	public Cart()
    	{
    	    Items = new Dictionary<string, CartItem>();
    	}
    }
    

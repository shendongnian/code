    class PriceLevels
    {
    	public int[] priceLevels { get; }
    	private static int[] defaultPriceLevels = { 2, 3, 3, 4, 5, 6 };
    
    	public PriceLevels(int[] newPriceLevels = null)
    	{
    		if (newPriceLevels == null) priceLevels = defaultPriceLevels;
    		else priceLevels = newPriceLevels;
    	}
    
    	public PriceLevels() : this(defaultPriceLevels)
    	{ }
    }

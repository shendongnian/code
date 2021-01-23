    class Item
    {
    	public int Prop1 {get; set;}
    	
    	public int Prop2 {get; set;}
    	
    	public string GetUniqueKey()
    	{
    		return Prop1.ToString() + "-" + Prop2.ToString();
    	}
    }
    
    public void DoWork()
    {
    	Random rnd = new Random();
    	
    	List<Item> items = new List<Item>();
    	
    	for(int i = 0; i < 600000; i++)
    	{
    		items.Add(new Item { Prop1 = rnd.Next(1, 10) });
    	}
    	
    	for(int i = 0; i < 600000; i++)
    	{
    		items[i].Prop2 = rnd.Next(1, 13);
    	}
    	
    	items
    		.GroupBy(item => item.GetUniqueKey())
            .Select(g => g.ToList())
    		.ToList();
    }

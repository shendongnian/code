    class Item 
    {
    	public static List<Item> Inventory = new List<Item>();
    	public Int32 Id { get; set; }
    	public Int32 Price { get; set; }
    	public String ItemName { get; set; }
    	private static Int32 NextId { get; set; } = 0;
    	private static Int32 TotalPrice { get; set; }
    	public Item(Int32 price, String name) 
    	{
    		this.Price = price;
    		this.ItemName = name;	
    		this.Id = NextId;	
    		Item.Inventory.Add(this);
    		Item.TotalPrice += price;
    		Item.NextId++;
    		// add to listbox or anything
    		// like listBox1.Items.Add($"{this.Id} | {this.ItemName} / {this.Price}");
    	}
    	public static Int32 GetTotalPrice()
    	{
    		return Item.TotalPrice;
    	}
    	public static void RemoveItem(Int32 Id) 
    	{ 
    		foreach ( Item _item in Item.Inventory )
    		{
    			if(_item.Id.Equals(Id)) 
    			{
    				Item.Inventory.Remove(_item);
    				break;
    			}
    		}
    	}
    }

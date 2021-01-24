    class Item
    {
    	public int ID;
    	public string name;
    }
    
    class Weapon : Item
    {
    	public int damage;
    }
    
    class Material : Item
    {
    	public int hardness;
    }
    
    
    void Main()
    {
    	List<Item> inventory = new List<Item>();
    	inventory.Add(new Weapon
    	{
    		name = "weapon",
    		ID = 1,
    		damage = 10,
    	});
    
    
    	inventory.Add(new Material
    	{
    		name = "material",
    		ID = 1,
    		hardness = 100,
    	});
    	
    	foreach (var item in inventory)
    	{
    		if (item is Weapon)
    		{
    			var weapon = item as Weapon;
    			weapon.Dump();
    		}
    		if (item is Material)
    		{
    			var material = item as Material;
    			material.Dump();
    		}
    	}
    
    }

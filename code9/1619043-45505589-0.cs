    using Newtonsoft.Json;
    void Main()
    {
    	var list = new List<IItem> { 
    	    new Appreciative("testing", 1, 2),
    	    new Unappreciative("testing", 3, 4)
    	};
    	
    	var json = JsonConvert.SerializeObject(list, 
               new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
    	
    	var newList = JsonConvert.DeserializeObject<List<IItem>>(json, 
               new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Objects });
    	
    	foreach (var item in newList) {
    		Console.WriteLine(item.GetType().Name);
    		Console.WriteLine(item.Quality);
    		item.UpdateQuality();
    		Console.WriteLine(item.Quality);
    	}
    }
    
    public interface IItem
    {
        string Name { get; set; }
        int SellIn { get; set; }
        int Quality { get; set; }
    	void UpdateQuality();
    }
    
    public abstract class Item : IItem
    {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
    
        public Item(string name, int sellIn, int quality)
        {
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }
    
        public virtual void UpdateQuality()
        {
            //Default Behaviour
        }
    }
    
    //Sub classes
    
    public class Appreciative : Item
    {
        public Appreciative(string name, int sellIn, int quality) 
                          : base(name, sellIn, quality)
        {}
    
        public override void UpdateQuality()
        {
            Quality = int.MaxValue;
        }
    }
    
    public class Unappreciative : Item
    {
        public Unappreciative(string name, int sellIn, int quality) 
                            : base(name, sellIn, quality)
        {}
    
        public override void UpdateQuality()
        {
            Quality = int.MinValue;
        }
    }

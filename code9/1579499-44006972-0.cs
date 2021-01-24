    namespace Test
    {
    public class Attack
    	{
    		public List<string> cost { get; set; }
    		public string name { get; set; }
    		public string text { get; set; }
    		public string damage { get; set; }
    		public int convertedEnergyCost { get; set; }
    	}
    
    	public class Weakness
    	{
    		public string type { get; set; }
    		public string value { get; set; }
    	}
    
    	public class Resistance
    	{
    		public string type { get; set; }
    		public string value { get; set; }
    	}
    
    	public class Ability
    	{
    		public string name { get; set; }
    		public string text { get; set; }
    		public string type { get; set; }
    	}
    
    	public class Card
    	{
    		public string id { get; set; }
    		public string name { get; set; }
    		public int nationalPokedexNumber { get; set; }
    		public string imageUrl { get; set; }
    		public string imageUrlHiRes { get; set; }
    		public string subtype { get; set; }
    		public string supertype { get; set; }
    		public string hp { get; set; }
    		public List<string> retreatCost { get; set; }
    		public string number { get; set; }
    		public string artist { get; set; }
    		public string rarity { get; set; }
    		public string series { get; set; }
    		public string set { get; set; }
    		public string setCode { get; set; }
    		public List<string> types { get; set; }
    		public List<Attack> attacks { get; set; }
    		public List<Weakness> weaknesses { get; set; }
    		public List<Resistance> resistances { get; set; }
    		public string evolvesFrom { get; set; }
    		public Ability ability { get; set; }
    		public List<string> text { get; set; }
    	}
    
    	public class RootObject
        {
    		public List<Card> cards { get; set; }
    
        }
    }

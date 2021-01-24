    void Main()
    {
    	using (FileStream fs = new FileStream(@"D:\t.txt", FileMode.Open))
    	{
    		using (StreamReader reader = new StreamReader(fs))
    		{
    			string line = reader.ReadToEnd();
    			
    			JsonConvert.DeserializeObject<RootObject>(line).Dump();
    		}
    	}
    }
    
    public class ItemDetail
    {
    	public string name1 { get; set; }
    	public string name2 { get; set; }
    }
    
    public class Item
    {
    	public string c_date { get; set; }
    	public string c_summary { get; set; }
    	public List<ItemDetail> ItemDetails { get; set; }
    }
    
    public class PArray
    {
    	public List<Item> Items { get; set; }
    }
    
    public class RootObject
    {
    	[JsonProperty(PropertyName = "$pArray")]
    	public PArray RootNode { get; set; }
    }

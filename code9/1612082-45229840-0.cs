	public class Foo
	{
	    public List<int> poo { get; set; }
	}
	public class RootObject
	{
	    public string name { get; set; }
	    public int price { get; set; }
	    public List<Foo> foo { get; set; }
	    public List<List<int>> importantdata { get; set; }
	}

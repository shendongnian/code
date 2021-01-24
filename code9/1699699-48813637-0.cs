    public class MyStuff
    {
    	public List<MyThing> Things { get; set; }
    }
    
    public class MyThing
    {
    	public string Name {get; set;}
    	public double SomeValue {get; set;}
    	public int SomeInt {get; set;}
    }
	var stuff = new MyStuff()
	{
		Things = new List<MyThing>()
		{
			new MyThing() { Name = "dfg", SomeValue = 0.3, SomeInt = 7 },
	        new MyThing() { Name = "fhc", SomeValue = 1.7, SomeInt = 8}
		}
	};
	
	var filtered = stuff.Things.Where(t => t.SomeValue > 1);

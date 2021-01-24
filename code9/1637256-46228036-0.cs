    public class Food
    {
    	public Food(string name)
    	{
    		Name = name;
    	}
    	
    	public string Name { get; set; }
    
    	public override string ToString()
    	{
    		return Name;
    	}
    }
	ArrayList a, b;
	a = new ArrayList();
	a.Add(new Food("Cocoa"));
	b = (ArrayList)a.Clone();
	
    // a, b now have "Chocolate" instead of "Cocoa"
	((Food)b[0]).Name = "Chocolate";
	
	Console.WriteLine(a[0]); // Prints "Chocolate"
	Console.WriteLine(b[0]); // Prints "Chocolate"

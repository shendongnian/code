    void Main()
    {
    	var regex = new Regex(@"('[\w\d ]+'|\d+)");
    	var input = new List<string> { "(1909, 'Ford', 'Model T')" };
    	var vehicles = new List<Vehicle>();
    	var id = 1;
    	
    	foreach (var line in input)
    	{
    		var matches = regex.Matches(line).Cast<Match>().ToArray();
    		var val1 = Int32.Parse(matches[0].Groups[1].Value);
    		var val2 = matches[1].Groups[1].Value;
    		var val3 = matches[2].Groups[1].Value;
    		
    		var vehicle = new Vehicle() { Id = id++, Year = val1, Make = val2, Model = val3 };
    		vehicles.Add(vehicle);
    	}
    }
    
    public class Vehicle
    {
    	public int Id { get; set; }
    	public int Year { get; set; }
    	public string Make { get; set;}
    	public string Model { get; set;}
    }

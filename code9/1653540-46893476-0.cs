    void Main()
    {
    	List<RailCar> railCars = new List<RailCar>();
    	
    	foreach(var railCar in railCars)
    	{
    		Console.WriteLine($"Error processing: RailCar number: {railCar.Number}. {railCar.OverFilled} is overfilled. {railCar.OverWeighed} is overweighed. {railCar.OverTotal} is over total.");
    	}
    }
    
    
    public class RailCar
    {
    	public string Number { get; set;}
    	
    	public int OverFilled { get; set; }
    	
    	public int OverWeighed { get; set; }
    	
    	public int OverTotal { get; set; }
    }

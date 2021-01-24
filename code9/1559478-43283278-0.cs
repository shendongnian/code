    public class Trip
    {
    	// Define a constructor for trip that takes a number of rooms
    	// Which will be provided by Ship.
    	public Trip(int numberOfRooms)
    	{
    		this.ArrayOfPeople = new Person[numberOfRooms];
    	}
    
    	// I removed the field arrayOfPeople becuase if you are just
    	// going to set and return the array without manipulating it
    	// you don't need a private field backing, just the property.
    	private Person[] ArrayOfPeople { get; set; }
    }
    
    public class Ship
    {
    	// Define a constructor that takes a number of rooms for Ship
    	// so Ship knows it's room count.
    	public Ship(int numberOfRooms)
    	{
    		this.NumberOfRooms = numberOfRooms;
    	}
    
    	// I removed the numberOfRooms field for the same reason
    	// as above for arrayOfPeople
    	public int NumberOfRooms { get; set; }
    }
    
    public class MyShipProgram
    {
    	public static void Main(string[] args)
    	{
    		// Create your ship with x number of rooms
    		var ship = new Ship(100);
    
    		// Now you can create your trip using Ship's number of rooms
    		var trip = new Trip(ship.NumberOfRooms);
    	}
    }

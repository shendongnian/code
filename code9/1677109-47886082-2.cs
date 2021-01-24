    //Lets seal the class to prevent inheritance unless you want to conform to O/C SOLID Principle
    public sealed class User
    {
    	public int Id {get;set;}
    	public IEnumerable<Booking> Bookings {get;set;}
    }

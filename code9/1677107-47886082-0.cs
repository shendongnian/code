    //Lets seal the class to prevent inheritance unless you want to conform O/C SOLID Principle
    public sealed class User
    {
    	public Id {get;set;}
    	public IEnumerable<Booking> {get;set;}
    }

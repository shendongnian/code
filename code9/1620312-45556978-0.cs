    abstract class Account 
    {
    	private decimal balance;
    	private decimal penalty;
    	private string accounttype;
    
    	public void MakeDeposit( decimal amount )
    	{
    		balance += amount;
    	}
    
        // ... and so on
    
    	public decimal Balance
    	{
    		get { return balance; }
            // This is new too... you'll need this 'set' method here in your Balance property.  More on that later.
    		set	{ balance = value; }
    	}
    }
    
    // Now we put the Main() method
    static void Main( string [] args )
    {
        // Your main program code goes here.
    }

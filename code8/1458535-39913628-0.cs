    public class BasePerson
    {
    	public string FirstName { get; set; }
    	public int Age { get; set; }
    }
    
    public class NormalPerson : BasePerson
    {   
    }
    
    public class BetterPerson : BasePerson
    {    
    }
    
    public class BestPerson : BasePerson
    {
    	string Address { get; set; }
    	int Score { get; set; }
    }

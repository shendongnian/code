    public abstract class BasePerson
    {
    	public string FirstName { get; set; }
    	public int Age { get; set; }
    
    	public abstract PersonType Type { get; }
    }
    public class NormalPerson : BasePerson
    {
       public override PersonType Type
       {
          get { return PersonType.Normal; }
       }
    }
    public class BetterPerson : BasePerson
    {
       public override PersonType PersonType
       {
          get { return PersonType.Better; }
       }
    }
    
    ...

    public enum Animal {Dog = 0, Cat = 1, Bird = 2}
    public class Person
    {
    	public Animal Pet {get; private set;}
    	
    	public Person()
    	{
    		Pet = Animal.Dog;
    	}
    	
    	public void Insert()
    	{
    		using(var con = DbFactory.CreateConnection(Database))
    		{
    			con.Query("stored_procedure_here", new { Pet = this.Pet}, CommandType.StoredProcedure);
    		}
    	}
 
    }

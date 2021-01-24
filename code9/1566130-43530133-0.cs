    public class Employee
    {
    	Person[] persons = new Person[3];
    	
    	//through constructor
    	public Employee()
    	{
    		persons[0].Name = "Ali";
    	}
    	
    	//method that takes index and name
    	public void AddPerson(int index, string name)
    	{
    		persons[index].Name = name;
    	}
    }

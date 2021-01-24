    public partial class Person
    {
    	public Person(Person p)
    	{
    		this.Name = p.Name;
    		this.FirstName = p.FirstName;
    		this.DisplayName = p.Name + ", " + p.FirstName;
    		this.Town = p.Town;
    		this.Age = p.Age;
    	}
    }

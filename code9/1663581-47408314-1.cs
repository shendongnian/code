    public class PersonMap : ClassMap<Person>
    {
    	public PersonMap()
    	{
    		AutoMap();
    		this.RemoveReference(p => p.Address);
    	}
    }

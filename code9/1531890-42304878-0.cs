    public class PersonRecord 
    {
        public string Id {get;set;}
        public string Name {get;set;}
    }
    
    public class Person : PersonRecord
    {
    	public DateTime Date {get;set;}
    	public int Age {get;set;}
    }

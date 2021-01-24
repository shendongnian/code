    public class Person
    {
     	public string Name {get;set;}
    	public int Age {get;set;}
    	public string City {get;set;}
    }
    var xml = @"<Person>
    	    <Name>John</Name>
    	    <Age>25</Age>
    	    <City>New York</City>
    	  </Person>";
    var people = XDocument.Parse(xml).Elements("Person")
    	 .Select(p => new Person 
    	 	{ 
    		  Name = p.Element("Name").Value, 
    		  Age = int.Parse(p.Element("Age").Value),
    		  City = p.Element("City").Value 
    		}).ToList();

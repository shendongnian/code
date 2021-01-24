    public class Program
    {
    	public static void Main()
    	{
    		var config = new MapperConfiguration(cfg => cfg.CreateMap<ListOfPersons, MyPersonObjectList>().BeforeMap((src, dest) =>
    		 {
    			 src.Persons = src.Persons.Take(24).ToList();
    		 }).ForMember(model => model.MyPersonObjects, opt => opt.MapFrom(contract => contract.Persons.Select(p => p.Name).ToList()))
    		 );
    		 
    		 var mapper = config.CreateMapper();
    		 
    		 ListOfPersons listFromApi = new ListOfPersons {
    		 	Persons = Enumerable.Range(0,100).Select(e => new Person{Name = "Person" + e})
    		 };
    				
    		var results = mapper.Map<MyPersonObjectList>(listFromApi);
    		
    		Console.WriteLine(results.MyPersonObjects.Count); //result is 24
    	}
    }
    
    public class ListOfPersons
    {
    	public IEnumerable<Person> Persons { get; set; }
    }
    
    public class Person
    {
    	public string Name { get; set; }
    }
    
    public class MyPersonObjectList
    {
    	public List<string> MyPersonObjects {get; set;}
    	
    	public MyPersonObjectList() {
    		MyPersonObjects = new List<string>();
    	}
    }

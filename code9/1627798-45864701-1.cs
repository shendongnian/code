    void Main()
    {
    	var Persons = new List<Person>() { new Person { CarIds = new List<int> { 1, 2, 3 } }, new Person { CarIds = new List<int> { 4, 5 } } };
    	var Cars = new List<Car>() { new Car { Id = 1 }, new Car { Id = 2 }, new Car { Id = 3 }, new Car { Id = 4 }, new Car { Id = 5 } };
    
    	(from p in Persons
    	 select new PersonDTO
    	 {
    		 Id = p.Id,
    		 Name = p.Name,
    		 Cars = Cars.Where(x => p.CarIds.Contains(x.Id)).ToList()
    	 }).ToList().Dump();
    }
    
    public class Person
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public List<int> CarIds { get; set; }
    }
    
    public class Car
    {
    	public int Id { get; set; }
    	public string Brand { get; set; }
    	public string Model { get; set; }
    	public int Year { get; set; }
    }
    public class PersonDTO
    {
    	public int Id { get; set; }
    	public string Name { get; set; }
    	public List<Car> Cars { get; set; }
    }

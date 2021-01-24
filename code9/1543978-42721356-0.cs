    void Main()
    {
    	IEnumerable<Person> people = new Person[] {
    		new Person(1,20,"Bob"),
    		new Person(1,22, "John"),
    		new Person(1,22, "Paul"),
    		new Person(1,20, "Kim"),
    		new Person(1,20, "Justin")
    	};
    	
    	List<Person> rankedPeople = new List<Person>();
    	
    	// just used for some sorting
    	Random r = new Random((int)DateTime.Now.Ticks); 
    	
    	// Group by age and sort them randomly 
    	foreach (var groupedPeople in people.GroupBy(p => p.Age) )
    	{
    		// Copy the persons from original list to a new one, at the sametime updating rank. 
    		rankedPeople.AddRange(  groupedPeople.OrderBy(gp => r.Next()).Select( (val,index)  =>  new Person(index,val.Age, val.Name) ) );  
    	}
    	
    	rankedPeople.ForEach(p => System.Console.WriteLine(p.ToString()));
    }
    
    
    public class Person
    {
    	public Person(int rank, int age, string name)
    	{
    		this.Rank = rank;
    		this.Age = age;
    		this.Name = name;
    	}
    	public int Rank { get; set; }
    	public int Age { get; set; }
    	public string Name { get; set; }
    	
    	public override string ToString()
    	{
    		return string.Format($"{Rank} {Age} {Name}");
    	}
    }

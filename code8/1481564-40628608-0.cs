    public class Program
    {
    	public static void Main()
    	{
    		var list = new List<Person>(){
    			new Person(){
    				Name = "1",
    				countryOfBirth = "USA",
    				birthDate = new DateTime(2000,1,1)
    			},
    				new Person(){
    				Name = "2",
    				countryOfBirth = "USA",
    				birthDate = new DateTime(1999,1,1)
    			},
    				new Person(){
    				Name = "3",
    				countryOfBirth = "USA",
    				birthDate = new DateTime(2000,1,1)
    			},
    				new Person(){
    				Name = "4",
    				countryOfBirth = "Other",
    				birthDate = new DateTime(2000,1,1)
    			},
    				new Person(){
    				Name = "5",
    				countryOfBirth = "SomeOther",
    				birthDate = new DateTime(2000,1,1)
    			}
    		};
    		var max = list.Where(p=> p.countryOfBirth == "USA").Max(a=> a.birthDate);
    		Console.WriteLine(max);
    		var maxList = list.Where(p=> p.countryOfBirth == "USA" && p.birthDate == max).ToList();
    		foreach(var p in maxList){
    			Console.WriteLine(p.Name);
    		}
    	}
    }
    
    class Person
    {
    	public string Name {get; set;}
         public DateTime birthDate { get; set; }
         public string countryOfBirth { get; set; }
    }

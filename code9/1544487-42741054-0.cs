    public class Person 
    {
      public string Name { get; set; }
      public int FirstNumber { get; set; }
      public int SecondNumber { get; set; }
    }
    
    public static void Main()
    {
      //list of persons
      List<Person> persons = new List<Person>();
     
      //Your piece of business logic ...
    
      //Creating person object
    
      var person = new Person();
      person.Name = Console.ReadLine();
      person.FirstNumber = Console.ReadLine();
      person.SecondNumber = Console.ReadLine();
      persons.Add(person);
    
      //order by FirstNumber (needed to add: System.Linq namespace)
      var orderedPersons = persons.OrderBy(p => p.FirstNumber);
    
      //output
      foreach(var p in orderedPersons)
      {
        Console.WriteLine(String.Format("{0} {1} {2}", p.Name, p.FirstNumber, p.SecondNumber));
      }
    }

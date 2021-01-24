    public class Person 
    {
      public string Name { get; set; }
      public int FirstNumber { get; set; }
      public int SecondNumber { get; set; }
    }
    
    public static void Main()
    {
      //list of persons
      List<Person> people = new List<Person>();
     
      //Your piece of business logic ...
    
      //Creating person object
    
      var person = new Person();
      person.Name = Console.ReadLine();
      person.FirstNumber = Console.ReadLine();
      person.SecondNumber = Console.ReadLine();
      people.Add(person);
    
      //order by FirstNumber (needed to add: System.Linq namespace)
      var orderedPeople = people.OrderBy(p => p.FirstNumber);
    
      //output
      foreach(var p in orderedPeople)
      {
        Console.WriteLine(String.Format("{0} {1} {2}", p.Name, p.FirstNumber, p.SecondNumber));
      }
    }

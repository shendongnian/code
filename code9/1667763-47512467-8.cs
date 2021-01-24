namespace ClassTest
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //Create a list to store people
      ICollection&lt;Person&gt; people = new List&lt;Person&gt;();
      //Add some people. Note that this is type-safe
      people.Add(new Person(){ Name = "John", Age = 23, FavouriteColour = "Blue" });
      people.Add(new Person(){ Name = "Doe", Age = 12});
      people.Add(new Person(){ Name = "Maria", Age = 41, FavouriteColour = "Purple" });
      people.Add(new Person(){ Name = "John", Age = 55, FavouriteColour = "Gray" }); //&lt;-- You can indeed have two people with the same name
      //Create queries to ensure correct sorting
      var peopleByName = from p in people
                         orderby p.Name
                         select p;
      var peopleByAge = from p in people
                        orderby p.Age
                        select p;
      var peopleByAgeDescending = from p in people
                                  orderby p.Age descending
                                  select p;
      //Execute the query and print results
      foreach(var person in peopleByAge)
      {
        Console.WriteLine("Hello, my name is {0} and I am {1} years old.", person.Name, person.Age);
        if(person.FavouriteColour != null)
        {
          Console.WriteLine("My favourite colour is {0}.", person.FavouriteColour);
        }
        else
        {
          Console.WriteLine("I have no favourite colour.");
        }
        Console.WriteLine(); //Add a new line for better readability
      }
    }
  }
  public class Person
  {
    public string Name { get; set; }
    public int Age { get; set; }
    public string FavouriteColour { get; set; }
  }
}

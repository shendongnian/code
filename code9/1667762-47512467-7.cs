    namespace DictionaryTest
    {
      public class Program
      {
        public static void Main(string[] args)
        {
          //Create a dictionary to store people
          Dictionary<string, int> people = new Dictionary<string, int>();
    
          //Add some people. Note that this is type-safe
          people.Add("John", 23);
          people.Add("Doe", 12);
          people.Add("Maria", 41);
          //people.Add("John", 55); // <-- This will fail because there is already a John
    
          //Create queries to ensure correct sorting
          var peopleByName = from p in people
                             orderby p.Key //Our name is the key, the age is the value
                             select new {Name = p.Key, Age = p.Value};
    
          var peopleByAge = from p in people
                            orderby p.Value
                            select new {Name = p.Key, Age = p.Value};
    
          var peopleByAgeDescending = from p in people
                                      orderby p.Value descending
                                      select new {Name = p.Key, Age = p.Value};
    
          //Execute the query and print results
          foreach(var person in peopleByAge)
          {
            Console.WriteLine("Hello, my name is {0} and I am {1} years old", person.Name, person.Age);
          }
        }
      }
    }

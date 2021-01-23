      static class Program
      {
        static IEnumerable<KeyValuePair<string, List<string>>> SliceBy(this IEnumerable<string> data, string delimiter)
        {
          string key = null;
          List<string> fruits = null;
    
          foreach (var item in data)
          {
            if (item == "Person")
            {
              if (key != null)
              {
                yield return new KeyValuePair<string, List<string>>(key, fruits);
              }
              key = item;
              fruits = new List<string>();
            }
            else // If the list
            {
              fruits.Add(item);
            }
          }
    
          if (key != null)
            yield return new KeyValuePair<string, List<string>>(key, fruits);
        }
    
        static void Main(string[] args)
        {
          var personFruits = new[] { "Person", "Apple", "Apple", "Cherry", "Apple", "Orange", "Person", "Grape", "Lemon", "Apple", "Apple" };
          var result = personFruits.SliceBy("Person").ToArray();
    
          foreach (var person in result)
          {
            Console.WriteLine(person.Key);
            foreach (var fruit in person.Value)
            {
              Console.WriteLine(fruit);
            }
    
            Console.WriteLine();
          }
    
        }

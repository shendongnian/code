      static class Program
      {
        static IEnumerable<KeyValuePair<string, List<string>>> SliceBy(this IEnumerable<string> data, string delimiter)
        {
          string key = null;
          List<string> values = null;
    
          foreach (var item in data)
          {
            if (item == delimiter)
            {
              if (key != null)
              {
                yield return new KeyValuePair<string, List<string>>(key, values);
              }
              key = item;
              values = new List<string>();
            }
            else
            {
              values.Add(item);
            }
          }
    
          if (key != null)
            yield return new KeyValuePair<string, List<string>>(key, values);
        }
    
        static void Main(string[] args)
        {
          var personFruits = new[] { "Person", "Apple", "Apple", "Cherry", "Apple", "Orange", "Person", "Grape", "Lemon", "Apple", "Apple", "Person", "Grape", "Lemon", "Apple", "Apple" };
          var result = personFruits.SliceBy("Person");
    
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
      }

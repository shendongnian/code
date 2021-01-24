    public class Person
    {
      public string Name { get; private set; }
      public Person(string name)
      {
        Name = name;
      }
    }
    public static class IEnumerableExtensions
    {
      public static List<T> WhereWithFiltered<T>(this IEnumerable<T> values
        ,Func<T, bool> predicate
        ,Action<IEnumerable<T>> filteredAction)
      {
        var result = values.Where(predicate).ToList();
        var filtered = values.Except(result);
        filteredAction(filtered);
        return result;
      }    
    }
    public void Log(IEnumerable<T> items)
    {
      foreach (var item in items)
      {
        Logger.Error($"Bad thing: {item} is wrong!");
      }
    }

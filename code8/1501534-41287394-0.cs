    public IList<IDictionary<string, string>> BuildDictionary<T>(HashSet<T> sourceSet, Func<T, string> toKey, Func<T, string> toMemberValue)
    {
      IList<IDictionary<string, string>> data = new List<IDictionary<string, string>>();
      
      foreach (var element in sourceSet)
      {
        Dictionary<string, string> newLookup = new Dictionary<string, string>();
        newLookup.Add(toKey(element), $"{toKey(element)},{toMemberValue(element)}");
        data.Add(newLookup);
      }
      
      return data;
    }
    void Main()
    {
      HashSet<ClassA> setOfAs = new HashSet<ClassA>(new[] { new ClassA { Code = "foo", Name = "bar" }, new ClassA { Code = "foo2", Name = "bar2" } });
      HashSet<ClassB> setOfBs = new HashSet<ClassB>(new[] { new ClassB { Code = "foo", Name = "bar" }, new ClassB { Code = "foo2", Name = "bar2" } });
      var lookupOfAs = BuildDictionary(setOfAs, x => x.Code, x => x.Name);
      var lookupOfBs = BuildDictionary(setOfBs, x => x.Code, x => x.Name);
    }
    // Define other methods and classes here
    public class ClassA
    {
      public string Code { get; set; }
      public string Name { get; set; }
    }
    public class ClassB
    {
      public string Code { get; set; }
      public string Name { get; set; }
    }

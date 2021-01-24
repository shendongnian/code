    static void Main(string[] args)
    {
      var connection = new List<User>()
      {
        new User(1, "ABC", null, true),
        new User(2, "DEF", 1, true),
        new User(3, "GHI", 1, true),
        new User(4, "JKL", null, true),
        new User(5, "MNO", 4, true),
        new User(6, "PRS", null, true),
        new User(7, "TUV", null, true),
        new User(8, "WX", 1, true),
        new User(9, "YZ", 4, true),
        new User(10, "abc", 7, true)
      };
      var filtered = connection.Where(x => x.Active).GroupBy(y => y.ParentID)
        .ToDictionary(gdc => gdc.Key ?? -1, gdc => gdc.ToList());
      foreach (var item in filtered)
      {
        Console.WriteLine($"ParentID: {item.Key}");
        foreach (var subItem in item.Value)
        {
          Console.WriteLine($"{subItem.ID} | {subItem.Name}");
        }
        
      }
    }

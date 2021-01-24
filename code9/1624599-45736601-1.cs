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
      var original = connection.Where(x => x.Active);
      var notNullOrdered = original.Where(x => x.ParentID != null).OrderBy(y => y.ParentID);
      var outputList = notNullOrdered.ToList();
      int insertionOffset = 0;
      foreach (var item in original.Select((value, i) => new { i, value }))
      {
        var value = item.value;
        var index = item.i + insertionOffset;
        if (value.ParentID == null)
        {
          outputList.Insert(index, value);
          ++insertionOffset;
        }
      }
      foreach (var subItem in outputList)
      {
        Console.WriteLine($"{subItem.ID} | {subItem.Name}");
      }
    }

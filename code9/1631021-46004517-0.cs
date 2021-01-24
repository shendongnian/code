    public static class MyExensions
    {
      public static void MyMethod(this IEnumerable<string> files)
      {
        foreach(var file in files)
        {
          ... Do stuff with file ...
        }
      }
    }

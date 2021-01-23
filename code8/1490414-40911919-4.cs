    public class MyClass
    {
      public string _answer;
      public DateTime? GetDate()
      {
          DateTime result;
          if (DateTime.TryParse(_answer, out result)) return result;
          return null;
      }
      public int? GetInt()
      {
          int result;
          if (int.TryParse(_answer, out result)) return result;
          return null;
      }
      // etc
    }

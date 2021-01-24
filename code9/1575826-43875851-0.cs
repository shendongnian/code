    public class MyModel
    {
      private readonly Dictionary<char,string> _prop = new
        Dictionary<char, string>
        {
          { 'c', "Captured" }
        };
      public char MyValue { get; set; }
      public string MyValueDisplay 
      {
        get 
        {
          string result;
          if (!_prop.TryGetValue(MyValue, out result))
          {
            result = "Default Value";
          }
          return result;
        }
      }
    }

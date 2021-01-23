    void Main()
    {
      var some = new SomeObject { List = { "Hi!", "There!" } };
      
      some.List.Dump();
    }
    
    public class SomeObject
    {
      public List<string> List { get; private set; }
      
      public SomeObject()
      {
        List = new List<string>();
      }
    }

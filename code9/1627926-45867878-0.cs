    [Serializable]
    public class Attributes
    {
      public int Relation {get; set;}
    public int YVersion {get; set;}
      public MyType W {get; set;}
      public Attributes()
      {
         W = new MyType();
      }
    
    }

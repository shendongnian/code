    public class Model1 
    {
      public string[] Fields { get; set; }
    
      public string prop1 { get { return Field[0]; } }
      public string prop2 { get { return Field[1]; } }
    }

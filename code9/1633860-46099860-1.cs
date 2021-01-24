    public class Setter : Base_Setter
    {
      public Setter() {}
      public Setter(string overrideValue) 
        : base(overrideValue)  { }
      
      public string Description { get; set; }
      public string Notes { get; set; }  
    }

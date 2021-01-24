    public class Child
    {
       [Key]
       public long Id {get; set;}
       public string Name {get; set;}
       public Gender Gender{get; set;} //Usually use Enum containing Female and Male
       public long FatherId{get; set;}
    
       public virtual Father Father {get; set;}
    }
    
    public class Father
    {
      public Father()
      {
         Children = new HashSet<Child>();
      }  
    
      [Key]
      public long Id {get; set;}
      public string Name {get; set;}
    
      public virtual ICollection<Child> Children{get; set;}
    }

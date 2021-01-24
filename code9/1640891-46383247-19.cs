    public class A : BaseEntity{
      public string Prop{ get; set; }
    }
    
    public class B : BaseEntity{
       [NavigationProperty]
       public virtual A A{ get; set; }
    }
    
    public class C : BaseEntity{
       [NavigationProperty]
       public virtual B B{ get; set; }
    }

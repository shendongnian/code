    public virtual class BaseClass
    {
      public void GetInheritorName()
      {
        var nameIs = this.InheritorTellMeYourName();
      }
    
      protected virtual string InheritorTellMeYourName()
      {
        return typeof(BaseClass).Name;
      }
    }
    
    public class A : BaseClass
    {
      protected override string InheritorTellMeYourName()
      {
         return typeof(A).Name;
      }
    }
    
    public class B : A
    {
    }

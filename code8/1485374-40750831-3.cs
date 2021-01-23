    public abstract class BaseClass
    {
      public void GetInheritorName()
      {
        var nameIs = this.InheritorTellMeYourName();
      }
    
      protected abstract string InheritorTellMeYourName();
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

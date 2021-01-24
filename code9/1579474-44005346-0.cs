    class BaseClass
    {
      public virtual void Print()
      {
         System.Console.WriteLine("BaseClass");
      }
    }
    
    class DerivedClass : BaseClass
    {
      public override void Print()
      {
         System.Console.WriteLine("DerivedClass");
      }
    }

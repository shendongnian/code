    public class BaseClass:IBase
    {
         private int A;
         private int B;
         public void IBase.SetA()
         {
              A=10;
         }
         public void SetB()
         {
              B=10;
         }
    }
    
    public class DerivedClass:BaseClass
    {
        public Set()
        {
              base.SetB();
              //method SetA will not accessible through base class, but will accessible with IBase interface
        }
    }

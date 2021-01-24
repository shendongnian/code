    public interface IParent {
      void Execute();
    }
    public class class1 : ParentClass {
       //Execute method implementation
    }
    public class class2 : ParentClass {
       // ...
    }
    public class class3 : ParentClass {
      // ....
    }
    public class MasterClass 
    {
        public void ExecutionMethod(IParent myObject)
        {
            //some code
            myObject.Execute();
            //some code
        }
    }

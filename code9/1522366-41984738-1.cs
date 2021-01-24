     public class Astore()
      {
          // factory method
          public A GetInstance()
          {
            return new A();
          }
        
        public class A
        {
          private A(){}
          public void MemberFunctionOfA()
          {
          // blah blah...
          }
        }
     }

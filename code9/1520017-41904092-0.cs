    public abstract class MyAbstractClass
      {
        // ... 
        private Something _myPrivateVariable; 
        // ...
        protected void MyProtectedMethod(string[] names) { // ... }
        // ... 
      }
        
    public class Caller:MyAbstractClass // inheriting the abstract class
     {
         public void GetAbstractMethod(){
         MyProtectedMethod(/*string[] values*/);
         } 
      }

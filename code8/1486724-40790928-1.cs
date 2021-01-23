    public abstract class SomeeClass{
       public SomeMethod(){
        CallMeMethod();
       }
    
       public bool TransformMeCalled {get;private set;}
    
       private void CallMeMethod() {
          TestMeClass testMeClass = new TestMeClass();
          testMeClass.TransformMe();
          TransformMeCalled = true;
       }
    }

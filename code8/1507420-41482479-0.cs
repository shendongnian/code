    public class MyClass<T> : IMyClass 
      where T: IT, new()
    {
      public void method()
      {
        IT obj= new T();
        //Some code
      }
    }
    
    public class MyClass : MyClass<ConcreteObject> 
    {
    }

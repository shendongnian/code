    public abstract class  Base // mark it as abstract if you don't need to use it in your code
    {
    }
    
    public class MyModel1
    {
    }
    
    public class MyModel2
    {
    }
    
    public class BaseClass<T> : Base //The class inherits the new class
    {
    }
    
    public class ChildClass1 : BaseClass<MyModel1>
    {
    }
    
    public class ChildClass2 : BaseClass<MyModel2>
    {
    }
    
    public class AnotherClass
    {
        public void MyMethod<T>()
        where T : Base
        {
        }
    }

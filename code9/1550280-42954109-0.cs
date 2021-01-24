    public class MyClass
    {
       IDependency _d;
       public MyClass(IDependency d)
       {
          _d = d;
       }
    }
    public class Dependency : IDependency
    {
    }

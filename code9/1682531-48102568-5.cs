    public delegate T Create<T>(T t);
    public class MyClass<T>
    {
        public void MyMethod(Create<T> create)
        {
             //...
        }
    }

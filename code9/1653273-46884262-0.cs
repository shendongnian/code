    class Program
    {
        static void Main(string[] args)
        {
            MyClass<SomeSomething, AnOperation<Something>> foo = 
            new MyClass<SomeSomething, AnOperation<Something>>(); 
            // AnOperation<SomeSomething> will cause a compile error.
            var bar = foo.GetAnOperationOfSomething();
            Console.WriteLine(bar != null);
            Console.Read();
        }
    }
    class MyClass<T, U>
        where T : Something
        where U : AnOperation<Something>
    {
        public U GetAnOperationOfSomething()
        {
            U anOperation = Activator.CreateInstance<U>();
            return anOperation;
        }
    }
    public class Something
    {
    }
    public class AnOperation<T>
        where T : Something
    {
    }
    public class SomeSomething : Something
    {
    }

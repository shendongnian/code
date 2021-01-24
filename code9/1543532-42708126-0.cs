    class Program
    {
        class MyClass { }
        class MyClass2 { }
        // wrapper classes for CustomMethod for each type
        class MyClassStrategy : Strategy<MyClass>
        {
            protected override void CustomMethod(MyClass t)
            {
                Console.WriteLine("MyClass");
            }
        }
        class MyClass2Strategy : Strategy<MyClass2>
        {
            protected override void CustomMethod(MyClass2 t)
            {
                Console.WriteLine("MyClass2");
            }
        }
        // base class for doing "common stuff"
        abstract class Strategy<T>
        {
            protected abstract void CustomMethod(T t);
            public virtual void Run(T t)
            {
                // do common stuff... 
                CustomMethod(t);
                // do more common stuff...
            }
        }
        // create an Invoke overload for each wrapper class
        static void Invoke(MyClass m) { new MyClassStrategy().Run(m); }
        static void Invoke(MyClass2 m2) { new MyClass2Strategy().Run(m2); }
        static void Main(string[] args)
        {
            // These compile OK:
            MyClass m = new MyClass();
            Invoke(m);
            MyClass2 m2 = new MyClass2();
            Invoke(m2);
            // This doesn't compile: 
            // (obviously, there are no Invoke overloads that take a string)
            Invoke("sdfdsff");
        }
    }

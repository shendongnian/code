    class Program
        {
            static void Main(string[] args)
            {
                MyClass<Something, AnOperation<Something>> obj = new MyClass<Something, AnOperation<Something>>();
            }
        }
    
        class MyClass<T, U>
            where T : Something
            where U : AnOperation<Something>
        {
            public U GetAnOperationOfSomething()
            {
                AnOperation<T> anOperation = new AnOperation<T>();
    
                return anOperation as U;
    
            }
        }
    
        public class Something
        {
        }
    
        public class AnOperation<T>
            where T : Something
        {
        }

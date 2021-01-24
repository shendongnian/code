    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var objMyClass = MyClass(); //gives error as compiler isn't emitting any default constructor
            }
        }
    
        public class MyClass
        {
            public MyClass(int i)
            {
    
            }
        }
    }

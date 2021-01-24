    public class Program
    {        
        static void Main(string[] args) {
            MyClass.Test();
        }
    }
    static class MyClass {
        static MyClass() {            
            throw new Exception("here we are");
        }
        public static void Test() {
            Console.WriteLine("test");
        }
    }

    class Test {
        public void test() {
            Console.WriteLine(this);
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            Test test = new Test();
            test.test();
        }
    }

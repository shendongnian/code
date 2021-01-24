    public class Test
    {
        public Test()
        {
            Program.TestInstanceCount++;
        }
        ~Test()
        {
            Program.TestInstanceCount--;
        }
    }
    class Program
    {
        public static volatile int TestInstanceCount = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(TestInstanceCount);
        }
    }

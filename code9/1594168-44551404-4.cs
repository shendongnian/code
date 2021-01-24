    public class Test
    {
        public Test()
        {
            System.Threading.Interlocked.Increment(ref Program.TestInstanceCount);
        }
        ~Test()
        {
            System.Threading.Interlocked.Decrement(ref Program.TestInstanceCount);
        }
    }
    class Program
    {
        public static int TestInstanceCount = 0;
        static void Main()
        {
            Console.WriteLine(TestInstanceCount);
        }
    }

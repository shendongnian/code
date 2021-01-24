    public class Test
    {
        public Test()
        {
            lock (Program.padlock)
            {
                Program.TestInstanceCount++;
            }
        }
        ~Test()
        {
            lock (Program.padlock)
            {
                Program.TestInstanceCount--;
            }
        }
    }
    class Program
    {
        public static object padlock = new object();
        public static int TestInstanceCount = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(TestInstanceCount);
        }
    }

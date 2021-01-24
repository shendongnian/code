    public class helper
    {
        private int counter = 0;
        private int returnCode = 0;
    
        public int Process()
        {
            Console.WriteLine("The application started ");
            StartTimer(2000);
            return returnCode;
        }
    
        private void StartTimer(int ms)
        {
            while (counter++ < 10)
            {
                System.Threading.Thread.Sleep(ms);
                Console.WriteLine("Timer is ticking");
            }
            returnCode = returnCode + 1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            helper helper = new helper();
            int code = helper.Process();
            Console.WriteLine("Main " + code.ToString());
            Console.ReadLine();
        }
    }

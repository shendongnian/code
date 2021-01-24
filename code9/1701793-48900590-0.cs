    class Program
    {
        static StringBuilder sb = new StringBuilder();
        static void Main()
        {
            Thread t = new Thread(WriteY);
            t.Start();
            for (int i = 0; i < 1000; i++)
            {
                //Console.Write("x");
                sb.Append("x");
                Thread.Sleep(10);
            }
            //t.Join();
            Console.WriteLine(sb.ToString());
        }
        private static void WriteY()
        {
            for (int i = 0; i < 1000; i++)
            {
                //Console.Write("y");
                sb.Append("y");
                Thread.Sleep(10);
            }
        }
    }

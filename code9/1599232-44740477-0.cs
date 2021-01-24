        static void Main(string[] args)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += Update;
            timer.Enabled = true;
            Console.ReadKey();
        }

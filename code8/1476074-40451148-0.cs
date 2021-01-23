    class MainClass
    {
        private static int delay { get; set; }
        private static int time_left { get; set; }
        public static void Main(string[] args)
        {
            
            delay = 8;
            time_left = delay;
            List<string> allEntries = new List<string>();
            Console.WriteLine("Please enter random things for the next 5 seconds");
            Console.SetCursorPosition(0, 2);
            System.Timers.Timer Timer = new System.Timers.Timer(1000);
            Timer.Elapsed += WriteTimeLeft;
            Timer.AutoReset = true;
            Timer.Enabled = true;
            Timer.Start();
            allEntries = Reader.ReadLine(10000);
            Timer.Stop();
            for (int i = 0; i < allEntries.Count; i++)
            {
                Console.WriteLine(allEntries[i]);
            }
            Console.Read();
        }
        public static void WriteTimeLeft(Object source, ElapsedEventArgs e)
        {
            int currentLineCursorTop = Console.CursorTop;
            int currentLineCursorLeft = Console.CursorLeft;
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 1);
            Console.Write(time_left);
            Console.SetCursorPosition(currentLineCursorLeft, currentLineCursorTop);
            Console.CursorVisible = true;
            time_left -= 1;
        }

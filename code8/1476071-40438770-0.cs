    class MainClass
    {
        private static int delay { get; set; }
        private static int time_left { get; set; }
        public static void Main(string[] args)
        {
            
            delay = 10;
            time_left = delay;
            List<string> allEntries = new List<string>();
            Console.WriteLine("Please enter random things for the next 10 seconds");
            Console.SetCursorPosition(0, 2);
            Timer();
            allEntries = Reader.ReadLine(11000);
            for (int i = 0; i < allEntries.Count; i++)
            {
                Console.WriteLine(allEntries[i]);
            }
            Console.Read();
        }
        public static void Timer()
        {
            for (int i = 11; i > 0; i--)
            {
                var t = Task.Delay(i*1000).ContinueWith(_ => WriteTimeLeft());
            }
        }
        public static void WriteTimeLeft()
        {
            int currentLineCursorTop = Console.CursorTop;
            int currentLineCursorLeft = Console.CursorLeft;
            Console.SetCursorPosition(0, 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, 1);
            Console.Write(time_left);
            Console.SetCursorPosition(currentLineCursorLeft, currentLineCursorTop);
            time_left -= 1;
        }
    }

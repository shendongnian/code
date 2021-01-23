        public static event EventHandler TestEvent;
        public static void Main(string[] args)
        {
            TestEvent += Program_TestEvent;
            TestEvent += Program_TestEvent;
            TestEvent += Program_TestEvent;
            TestEvent(null, EventArgs.Empty);
         }
        private static void Program_TestEvent(object sender, EventArgs e)
        {
            Console.WriteLine("EVENT");
        }
       
        //output: 
        //EVENT
        //EVENT
        //EVENT

    class Program
    {
        private static SerialPort myPort;
        static void Main(string[] args)
        {
            var timer = new System.Timers.Timer { Interval = 5000, Enabled = true };
            timer.Elapsed += OnTimedEvent;
            myPort = new SerialPort { BaudRate = 9600, PortName = "COM4" };
            myPort.Open();
            if (myPort.IsOpen)
            {
                myPort.WriteLine("You are are now connected to GDC-IoT Number 1");
                myPort.WriteLine("ALETS - Actionable Law Enforcment Technology Software");
            }
            // Listen to serial port
            while (true)
            {                
                Console.WriteLine(myPort.ReadLine());
            }
        }
        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (myPort == null)
            {
                Console.WriteLine("Port has not yet been assigned");
            }
            else if (!myPort.IsOpen)
            {
                Console.WriteLine("Port is not open");
            }
            else
            {
                Console.WriteLine("Sending ping...");
                myPort.WriteLine("PING");
            }
        }
    }

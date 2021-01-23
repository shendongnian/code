    internal class Program
    {
        private static readonly AutoResetEvent RxDataReady = new AutoResetEvent(false);
        private static event EventHandler ev;
        public static void GetSomeDataFromSerialPort()
        {
            RxDataReady.WaitOne();
            // Process data
        }
        private static void Main()
        {
            ev += ReadDataEventHandler;
            Task.Run(
                async () =>
                    {
                        await Task.Delay(5000);
                        ev(null, EventArgs.Empty);
                    });
            GetSomeDataFromSerialPort();
            Console.WriteLine("Done.");
            Console.ReadLine();
        }
        private static void ReadDataEventHandler(object sender, EventArgs eventArgs)
        {
            // Prepare data
            RxDataReady.Set();
        }
    }

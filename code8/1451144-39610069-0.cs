    public class Program
    {
        static ManualResetEventSlim latestIDIisNotNUll = new ManualResetEventSlim();
        public static void Main()
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                UpdateLatestTaskID();
            });
            int latestTaskId = GetLatestTaskID();
            Console.WriteLine("Latest Task ID: " + latestTaskId);
            Console.ReadLine();
        }
        private static void UpdateLatestTaskID()
        {
            //Your update code
            Console.WriteLine("Latest ID is set");
            latestIDIisNotNUll.Set();
        }
        private static int GetLatestTaskID()
        {
            Console.WriteLine("Wating for latest ID");
            latestIDIisNotNUll.Wait();
            int latestTaskId = 5;//_repo.GetLatestTaskID(bookingRequest.CaseId);
            return latestTaskId;
        }
    }

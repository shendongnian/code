    // This is a very crude implementation, but it should serve its purpose.
    using System.Threading.Tasks;
    public class App
    {
        public bool isAppActive = true;
        public static void Main()
        {
            Task mytsk = MyLog();
            Console.ReadKey();
            isAppActive = false;
        }
        public static async void MyLog()
        {
            while (App.isAppActive)
            {
                Thread.Sleep(60000);
                // Write your variable to a file (using an async method and await)
            }
        }
    }

    class Program
    {
        public static bool onVPN;
         static void Main(string[] args)
        {
            CheckVPN();
            CheckIfInternal();
            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
        public static void CheckVPN()
        {
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                //crude way to check if the VPN adapter is running
                if (adapter.Description == "VPN Adapter")
                {
                   onVPN = true;
                }
                else
                {
                    onVPN = false;
                }
            }
        }

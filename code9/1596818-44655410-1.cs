    static void Main(string[] args)
    {
        int KB = 1024;
        int MB = KB * KB;
        int GB = MB * KB;
        long TB = (long)GB * KB;
        NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
        foreach (NetworkInterface nic in nics)
        {
            if (nic.NetworkInterfaceType != NetworkInterfaceType.Loopback
                && nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                && nic.OperationalStatus == OperationalStatus.Up
                && nic.Name.StartsWith("vEthernet") == false
                && nic.Description.Contains("Hyper-v") == false)
            {
                Console.WriteLine(nic.Description);
                // 1. Convert bits to bytes
                // 5. Convert result to decimal
                decimal speed = (decimal)nic.Speed / 8;
                // 2. Do comparisons with our variables and
                // 3. Include all possible conditions (starting with > TB)
                if (speed >= TB)
                {
                    // 4. Divide the speed by the display size
                    // 5. Format the output to show 3 decimal places
                    Console.WriteLine("Speed: {0:0.000} TB/S", speed / TB);
                }
                else if (speed >= GB)
                {
                    Console.WriteLine("Speed: {0:0.000} GB/S", speed / GB);
                }
                else if (speed >= MB)
                {
                    Console.WriteLine("Speed: {0:0.000} MB/S", speed / MB);
                }
                else if (speed >= KB)
                {
                    Console.WriteLine("Speed: {0:0.000} KB/S", speed / KB);
                }
                else
                {
                    Console.WriteLine("Speed: {0:0.000} Bytes per second", speed);
                }
            }
        }
        Console.Write("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }

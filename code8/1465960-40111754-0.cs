    static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            var ip1 = IPAddress.Parse("192.168.0.1");
            var ip2 = IPAddress.Parse("192.168.1.40");
            var mask = IPAddress.Parse("255.255.255.0");
            bool inSameNet = ip1.IsInSameSubnet(ip2, mask);
            IPAddress broadcast = GetBroadcastAddress(ip2, mask);
            IPAddress net = GetNetworkAddress(ip2, mask);
            Console.WriteLine(broadcast);
            Console.WriteLine(net);
            Console.ReadKey();
        }

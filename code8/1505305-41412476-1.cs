    namespace ITDevices
    {
        /*Device Modal*/
        public class Device
        {
            public string IP { get; set; }
            public string Name { get; set; }
            public string MAC { get; set; }
        }
        /*Entry Class*/
        class Program
        {
            static void Main(string[] args)
            {
                List<Task<Device>> Tasks = new List<Task<Device>>();
                for (int i = 2; i != 0; i--)
                {
                    Tasks.Add(Task.Factory.StartNew<Device>(
                        () => {
                            Device free = Helper.GetFreeDevice();
                            return free;
                        }
                        ));
                }
                Task.WhenAll(Tasks.ToArray()).Wait();
                foreach (Task<Device> item in Tasks)
                {
                    Console.WriteLine(item.Result.IP);
                }
                Console.ReadLine();
            }
        }
        /*Devices Helper*/
        static class Helper
        {
            public static List<Device> UsedDevices = new List<Device>();
            static List<Device> OnlineDevices = new List<Device>()
            {
                new Device { IP="192.168.1.15",Name="PerryLabtop",MAC="AC:DS:F2:CC:2D:7A"},
                new Device { IP="192.168.1.20",Name="MAYA-PC",MAC="7D:E9:2C:FF:E7:2D"},
                new Device { IP="192.168.1.2",Name="server",MAC="D8:C2:A4:DC:E5:3A"}
            };
            static Object LockObject = new Object();
            public static Device GetFreeDevice()
            {
                lock (LockObject)
                {
                    Device FreeDevice = OnlineDevices.Where(x => !UsedDevices.Contains(x)).FirstOrDefault();
                    if (FreeDevice != null)
                        UsedDevices.Add(FreeDevice);
                    return FreeDevice;
                }
            }
        }
    }

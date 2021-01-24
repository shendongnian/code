    using System;
    using WIA;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            DoWork();
            Console.ReadKey();
        }
        
        private static void DoWork()
        {
            var deviceManager1 = new DeviceManager();
            for (int i = 1; (i <= deviceManager1.DeviceInfos.Count); i++)
            {
                if (deviceManager1.DeviceInfos[i].Type == WiaDeviceType.CameraDeviceType|| deviceManager1.DeviceInfos[i].Type == WiaDeviceType.VideoDeviceType)
                {
                    Console.WriteLine(deviceManager1.DeviceInfos[i].Properties["Name"].get_Value().ToString());
                }
            }
        }
    }

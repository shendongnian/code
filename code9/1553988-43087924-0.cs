    using System;
    using System.Management;
    
    namespace akWmiDeviceDemo
    {
        class Program
        {
            static void Main(string[] args)
            {
            //  inspired by:
            //  https://blogs.msdn.microsoft.com/powershell/2007/02/24/displaying-usb-devices-using-wmi/
                string strComputer = ".";
                ManagementScope scope = new ManagementScope(@"\\" + strComputer + @"\root\cimv2");
                ObjectQuery queryUsbControllers = new ObjectQuery("Select * From Win32_USBControllerDevice");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, queryUsbControllers);
                ManagementObjectCollection usbControllers = searcher.Get();
    
                foreach (ManagementObject usbController in usbControllers)
                {
                    string dependent = (string)usbController["Dependent"];
                    string[] names = dependent.Replace("\"", "").Split(new char [] {'='});
                    string strUsbControllerName = names[1];
                    ObjectQuery queryUsbDevices = new ObjectQuery("Select * From Win32_PnPEntity Where DeviceID = '" + strUsbControllerName + "'");
                    ManagementObjectSearcher deviceSearcher = new ManagementObjectSearcher(scope, queryUsbDevices);
                    ManagementObjectCollection usbDevices = deviceSearcher.Get();
    
                    o("");
                    o("USB controller = {0}", strUsbControllerName);
                    foreach (ManagementObject usbDevice in usbDevices)
                    {
                        o("description = {0}", usbDevice["Description"]);
                        o("PnPDeviceID = {0}", usbDevice["PnPDeviceID"]);
                    }
                }
            }
    
            static void o(string format, params object[] args)
            {
                Console.WriteLine(format, args);
            }
        }
    }

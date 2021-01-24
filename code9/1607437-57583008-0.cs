    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management;
    
    namespace CsharpUSBConnetctionInfo
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (var usbDevice in usbDevices)
                {
                    Console.WriteLine("Device ID: {0}, PNP Device ID: {1}, Description: {2}", usbDevice.DeviceID, usbDevice.PnpDeviceID, usbDevice.Description);
                }
    
                Console.ReadLine();
            }
    
            static List<USBDeviceInfo> GetUSBDevices()
            {
                List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
    
                ManagementObjectCollection collection;
    
                using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub")) collection = searcher.Get();
                foreach (var device in collection)
                {
                    devices.Add(new USBDeviceInfo(
                        (string)device.GetPropertyValue("DeviceID"),
                        (string)device.GetPropertyValue("PNPDeviceID"),
                        (string)device.GetPropertyValue("Description")
                        ));
                }
    
                collection.Dispose();
                return devices;
    
            }
        }
    
        class USBDeviceInfo
        {
            public USBDeviceInfo(string deviceID, string pnpDeivceID, string description)
            {
                this.DeviceID = deviceID;
                this.PnpDeviceID = pnpDeivceID;
                this.Description = description;
            }
    
            public string DeviceID
            {
                get;
                private set;
            }
    
            public string PnpDeviceID
            {
                get;
                private set;
            }
    
            public string Description
            {
                get;
                private set;
            }
        }
    }

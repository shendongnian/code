    class Program {
        static void Main(string[] args) {
            string DeviceActualName = "Fan Control";
            FTDI usbDev = new FTDI();
            UInt32 devCount = 0;
            usbDev.GetNumberOfDevices(ref devCount);
            FTDI.FT_DEVICE_INFO_NODE[] infoNode = new FTDI.FT_DEVICE_INFO_NODE[devCount];
            string SerialNumber = null;
            usbDev.GetDeviceList(infoNode);
            foreach(FTDI.FT_DEVICE_INFO_NODE node in infoNode) {
                if(node != null && node.Description.Equals(DeviceActualName)) {
                    Console.WriteLine("Found: {0} // {1}", node.Description, node.SerialNumber);
                    SerialNumber = node.SerialNumber;
                }
            }
            var usbDevices = GetUSBDevices();
            foreach(var usbDevice in usbDevices) {
                if(usbDevice.Name != null)
                    if(usbDevice.Name.Contains("COM") && usbDevice.PnpDeviceID.Contains(SerialNumber)) {
                        Console.WriteLine("Match Found:  {0} // {1}", usbDevice.Name, usbDevice.PnpDeviceID);
                        Console.WriteLine("ComPort: {0}", usbDevice.Name[(usbDevice.Name.IndexOf("COM") + 3)]);
                    }
            }
            Console.Read();
        }
        static List<USBDeviceInfo> GetUSBDevices() {
            List<USBDeviceInfo> devices = new List<USBDeviceInfo>();
            ManagementObjectCollection collection;
            using(var searcher = new ManagementObjectSearcher(@"SELECT * FROM Win32_PnPEntity"))
                collection = searcher.Get();
            foreach(var device in collection) {
                devices.Add(new USBDeviceInfo(
                (string) device.GetPropertyValue("Name"),
                (string) device.GetPropertyValue("PNPDeviceID")
                ));
            }
            collection.Dispose();
            return devices;
        }
        class USBDeviceInfo {
            public USBDeviceInfo(string Name, string pnpDeviceID) {
                this.Name = Name;
                this.PnpDeviceID = pnpDeviceID;
            }
            public string Name { get; private set; }
            public string PnpDeviceID { get; private set; }
        }
    }

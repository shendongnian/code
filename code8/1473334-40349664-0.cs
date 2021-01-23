    public class ComPortFinder
    {
        public static List<DeviceInfo> FindConnectedDevices(uint vid, uint pid)
        {
            string pattern = string.Format("^VID_{0:X4}.PID_{1:X4}", vid, pid);
            Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
            List<DeviceInfo> devices = new List<DeviceInfo>();
            RegistryKey rk1 = Registry.LocalMachine;
            RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
            foreach (String s3 in rk2.GetSubKeyNames())
            {
                RegistryKey rk3 = rk2.OpenSubKey(s3);
                foreach (String s in rk3.GetSubKeyNames())
                {
                    if (_rx.Match(s).Success)
                    {
                        RegistryKey rk4 = rk3.OpenSubKey(s);
                        foreach (String s2 in rk4.GetSubKeyNames())
                        {
                            RegistryKey rk5 = rk4.OpenSubKey(s2);
                            RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                            if (!string.IsNullOrEmpty((string)rk6.GetValue("PortName")))
                            {
                                DeviceInfo di = new DeviceInfo()
                                {
                                    VenderId = vid,
                                    ProductId = pid,
                                    SerialNumber = "UNKNOWN",
                                    ComPort = rk6.GetValue("PortName").ToString()
                                };
                                devices.Add(di);
                            }
                        }
                    }
                }
            }
            return devices;
        }
    }
    public struct DeviceInfo
    {
        public uint VenderId;
        public uint ProductId;
        public string SerialNumber;
        public string ComPort;
    }

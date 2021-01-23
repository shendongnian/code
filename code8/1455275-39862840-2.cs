    using System.Collections.Generic;
    using System.Linq;
    using System.Management; // Add a reference to System.Management for the project
    using System.Net.NetworkInformation;
    
    namespace ConsoleApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                HashSet<string> physicalMacAddresses = new HashSet<string>(GetMacAddressesOnPciBus());
    
                var ifaces = NetworkInterface.GetAllNetworkInterfaces();
                var physicalAddresses = ifaces
                    .Where(x => x.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                    && physicalMacAddresses.Contains(x.GetPhysicalAddress().ToString().Trim('{').Trim('}')));
    
            }
    
            private static IEnumerable<string> GetMacAddressesOnPciBus()
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher
        ("Select MACAddress,PNPDeviceID FROM Win32_NetworkAdapter WHERE MACAddress IS NOT NULL AND PNPDeviceID IS NOT NULL");
                ManagementObjectCollection mObject = searcher.Get();
    
                foreach (ManagementObject obj in mObject)
                {
                    string pnp = obj["PNPDeviceID"].ToString();
                    if (pnp.Contains("PCI\\"))
                    {
                        string mac = obj["MACAddress"].ToString();
                        mac = mac.Replace(":", string.Empty);
                        yield return mac;
                    }
                }
            }
        }
    }

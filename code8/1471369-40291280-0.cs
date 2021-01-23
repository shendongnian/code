    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication14
    {
        class Program
        {
            static void Main(string[] args)
            {
                IPAddress address = IPAddress.Parse("12.3.0.42");
                byte[] t = GetMacAddress(address);
                string mac = string.Join(":", (from z in t select z.ToString("X2")).ToArray());
                Console.WriteLine(mac);
                Console.ReadLine();
            }
    
            [DllImport("iphlpapi.dll", ExactSpelling = true)]
            public static extern int SendARP(uint destIP, uint srcIP, byte[] macAddress, ref uint macAddressLength);
    
            public static byte[] GetMacAddress(IPAddress address)
            {
                byte[] mac = new byte[6];
                uint len = (uint)mac.Length;
                byte[] addressBytes = address.GetAddressBytes();
                uint dest = ((uint)addressBytes[3] << 24)
                  + ((uint)addressBytes[2] << 16)
                  + ((uint)addressBytes[1] << 8)
                  + ((uint)addressBytes[0]);
                if (SendARP(dest, 0, mac, ref len) != 0)
                {
                    throw new Exception("The ARP request failed.");
                }
                return mac;
            }
        }
    }
     

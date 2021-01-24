    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SystemInfo
    {
        class Program
        {
            class SysInfo
            {
                public string win, net, cpu;
                public string hostname, username;
    
                public SysInfo()
                {
                    net = Environment.Version.ToString();
                    win = Environment.OSVersion.ToString();
                    cpu = Environment.ProcessorCount.ToString();
                    hostname = Environment.MachineName.ToString();
                    username = Environment.UserName.ToString();
                }
            }
            static void Main()
            {
                string p;
    
                SysInfo info = new SysInfo();
                while (true)
                {
                 p = Console.ReadLine();
     
                 switch (p)
                 {
                     case "cpu":
                         Console.WriteLine("CPU count: {0}", info.cpu);
                         break;
                     case "win":
                         Console.WriteLine("Windows Version: {0}", info.win);
                         break;
                     case "net":
                         Console.WriteLine(".NET Version: {0}", info.net);
                         break;
                     case "host":
                         Console.WriteLine("Hostname: {0}", info.hostname);
                         break;
                     case "user":
                         Console.WriteLine("Username: {0}", info.username);
                         break;
                     default:
                         Console.WriteLine("Usage: sysinfo <cpu|win|net|host|user>");
                         break;
                 }
                }
            }
        }
    }

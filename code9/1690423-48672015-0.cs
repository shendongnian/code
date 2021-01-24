        using System;
    using System.Text;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.ComponentModel;
    using System.Threading;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Linq;
    using System.Configuration;
    using System.Threading.Tasks;
    
    namespace pingtask
    {
        class Program
        {
            static void Main(string[] args)
            {
    		
                Task task = new Task(makePing);
                task.Start();
                task.Wait();
    			Console.WriteLine("Test finished.");
                Console.ReadLine();
    
            }
    
            static async void makePing()
            {
    
                Ping ping = new Ping();
                byte[] buffer = new byte[32];
                PingOptions pingoptns = new PingOptions(128, true);
                int timeOut = 4000;
    
                List<string> list_Eq = new List<string>();
                list_Eq.Add("192.168.23.33");
                list_Eq.Add("192.168.0.11");
                list_Eq.Add("192.168.0.7");
                list_Eq.Add("192.168.0.8");
                list_Eq.Add("192.168.0.9");
                list_Eq.Add("192.168.0.5");
                list_Eq.Add("192.168.0.1");
                list_Eq.Add("192.168.0.2");
                list_Eq.Add("192.168.0.3");
                list_Eq.Add("192.168.0.10");
                list_Eq.Add("192.168.0.14");
                list_Eq.Add("192.168.0.4");
    
                foreach (var item in list_Eq)
                {
                    Console.WriteLine("ADDRESS:" + item);
                    PingReply reply = await ping.SendPingAsync(item, timeOut, buffer, pingoptns);
    				Console.WriteLine("TIME:" + reply.RoundtripTime);
                    Console.WriteLine("==============================");
                }
    
            }
        }
    }

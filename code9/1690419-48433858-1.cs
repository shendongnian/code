    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Net;
    using System.Net.Sockets;
    using System.Net.NetworkInformation;
    using System.Threading;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IP", typeof(string));
                dt.Columns.Add("Completed", typeof(bool));
                dt.Columns.Add("Canceled", typeof(bool));
                dt.Columns.Add("Error", typeof(string));
                dt.Columns.Add("Ping", typeof(Ping));
                dt.Columns.Add("Reply", typeof(PingReply));
                dt.Rows.Add(new object[] {"172.160.1.19", false, false});
                dt.Rows.Add(new object[] { "172.160.1.27", false, false });
                dt.Rows.Add(new object[] { "172.160.1.37", false, false });
                dt.Rows.Add(new object[] { "172.160.1.57", false, false});
                MyPing ping = new MyPing(dt); 
            }
        }
        public class MyPing
        {
            static AutoResetEvent waiter = new AutoResetEvent(false);
            DataTable dt;
            Dictionary<string, DataRow> pingDict = new Dictionary<string, DataRow>();
            const int TIMEOUT = 30000;
            public MyPing() { }
            public MyPing(DataTable dtin)
            {
                dt = dtin;
                Console.WriteLine("Haciendo ping a los equipos, no cierre esta ventana... ");
                
                string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                // Por cada IP se realiza ping y se  agrega a la lista del modelo
                foreach (DataRow item in dt.Rows)
                {
                    Ping ping = new Ping();
                    string ip = item.Field<string>("IP");
                    pingDict.Add(ip, item);
                    ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    PingOptions pingoptns = new PingOptions(128, true);
                    Console.WriteLine("send : {0}", ip);
                    ping.SendAsync(ip, TIMEOUT, buffer, pingoptns, item);
                }
                waiter.WaitOne();
            }
            private void PingCompletedCallback (object sender, PingCompletedEventArgs e)
            {
                Object thisLock = new Object();
                lock (thisLock)
                {
                    DataRow row = e.UserState as DataRow;
                    // If the operation was canceled, display a message to the user.
                    if (e.Cancelled)
                    {
                        row.SetField<bool>("Canceled", true);
                        return;
                    }
                    // If an error occurred, display the exception to the user.
                    if (e.Error != null)
                    {
                        row.SetField<string>("Error", e.Error.Message);
                    }
                    else
                    {
                        row.SetField<bool>("Completed", true);
                    }
                    string replyIP = e.Reply.Address.ToString();
                    row.SetField<PingReply>("Reply", e.Reply);
                    string sendIP = row.Field<string>("IP");
                    Console.WriteLine("reply IP : {0}, send IP : {1}", replyIP, sendIP);
                    pingDict.Remove(sendIP); 
                    if (pingDict.Count == 0) waiter.Set();
                }
            }
        }
    }

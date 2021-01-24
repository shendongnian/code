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
                dt.Columns.Add("TimeOut", typeof(int));
                dt.Columns.Add("Canceled", typeof(bool));
                dt.Columns.Add("Error", typeof(List<string>));
                dt.Columns.Add("Reply", typeof(List<PingReply>));
                dt.Columns.Add("Sent", typeof(int));
                dt.Columns.Add("Received", typeof(int));
                dt.Rows.Add(new object[] { "172.160.1.19", 0, false, null, null, 4, 0 });
                dt.Rows.Add(new object[] { "172.160.1.27", 0, false, null, null, 4, 0 });
                dt.Rows.Add(new object[] { "172.160.1.37", 0, false, null, null, 4, 0 });
                dt.Rows.Add(new object[] { "172.160.1.57", 0, false, null, null, 4, 0 });
                MyPing ping = new MyPing(dt); 
            }
        }
        public class MyPing
        {
            static AutoResetEvent waiter = new AutoResetEvent(false);
            const string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            private Object thisLock = new Object();
            DataTable dt;
            Dictionary<string, DataRow> pingDict = new Dictionary<string, DataRow>();
            const int TIMEOUT = 12000;
            public MyPing() { }
            public MyPing(DataTable dtin)
            {
                dt = dtin;
                Console.WriteLine("Haciendo ping a los equipos, no cierre esta ventana... ");
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
                lock (thisLock)
                {
                    DataRow row = null;
                    try
                    {
                        row = e.UserState as DataRow;
                        string sendIP = row.Field<string>("IP");
                        string replyIP = e.Reply.Address.ToString();
                        Console.WriteLine("reply IP : {0}, send IP : {1}", replyIP, sendIP);
                        // If the operation was canceled, display a message to the user.
                        if (e.Cancelled)
                        {
                            row.SetField<bool>("Canceled", true);
                            return;
                        }
                        // If an error occurred, display the exception to the user.
                        if (e.Error != null)
                        {
                            if (row["Error"] == DBNull.Value) row["Error"] = new List<string>();
                            row.Field<List<string>>("Error").Add(e.Error.Message);
                        }
                        if (e.Reply.Status == IPStatus.TimedOut)
                        {
                            row["TimeOut"] = row.Field<int>("TimeOut") + 1;
                        }
                        else
                        {
                            if (row["Reply"] == DBNull.Value) row["Reply"] = new List<PingReply>();
                            row.Field<List<PingReply>>("Reply").Add(e.Reply);
                            row["Received"] = row.Field<int>("Received") + 1;
                        }
                        row["Sent"] = row.Field<int>("Sent") - 1;
                        if (row.Field<int>("Sent") > 0)
                        {
                            Ping ping = new Ping();
                            string ip = row.Field<string>("IP");
                            ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                            byte[] buffer = Encoding.ASCII.GetBytes(data);
                            PingOptions pingoptns = new PingOptions(128, true);
                            Console.WriteLine("send : {0}", ip);
                            ping.SendAsync(ip, TIMEOUT, buffer, pingoptns, row); ;
                        }
                        else
                        {
                            pingDict.Remove(sendIP);
                            if (pingDict.Count == 0) waiter.Set();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception : {0}", ex.Message);
                    }
                }
            }
        }
    }

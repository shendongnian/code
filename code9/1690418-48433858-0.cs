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
                dt.Rows.Add(new object[] {"192.168.1.19"});
                dt.Rows.Add(new object[] { "192.168.1.27" });
                dt.Rows.Add(new object[] { "192.168.1.37"});
                dt.Rows.Add(new object[] { "192.168.1.57"});
                MyPing ping = new MyPing(dt); 
            }
        }
        public class MyPing
        {
            static AutoResetEvent waiter = new AutoResetEvent(false);
            DataTable dt;
            Dictionary<string, State> pingDict = new Dictionary<string, State>();
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
                    State state = new State(ip, ping);
                    pingDict.Add(ip, state);
                    ping.PingCompleted += new PingCompletedEventHandler(PingCompletedCallback);
                    byte[] buffer = Encoding.ASCII.GetBytes(data);
                    PingOptions pingoptns = new PingOptions(128, true);
                    Console.WriteLine("send : {0}", ip);
                    ping.SendAsync(ip, TIMEOUT, buffer, pingoptns, state);
                }
                waiter.WaitOne();
            }
            private void PingCompletedCallback (object sender, PingCompletedEventArgs e)
            {
                Object thisLock = new Object();
                lock (thisLock)
                {
                    State state = e.UserState as State;
                    // If the operation was canceled, display a message to the user.
                    if (e.Cancelled)
                    {
                        state.canceled = true;
                        return;
                    }
                    // If an error occurred, display the exception to the user.
                    if (e.Error != null)
                    {
                        state.error = e.Error.Message;
                    }
                    else
                    {
                        state.completed = true;
                    }
                    string ip = e.Reply.Address.ToString();
                    state.reply = e.Reply;
                    Console.WriteLine("reply IP : {0}, send IP : {1}", ip, state.ip);
                    pingDict.Remove(state.ip); 
                    if (pingDict.Count == 0) waiter.Set();
                }
            }
        }
        public class State
        {
            public string ip { get; set; }
            public bool completed { get; set; }
            public bool canceled { get; set; }
            public string error { get; set; }
            public Ping ping { get; set; }
            public PingReply reply { get; set; }
            public State() { }
            public State(string ip, Ping ping)
            {
                this.ip = ip;
                this.ping = ping;
                completed = false;
                canceled = false;
            }
        }
    }

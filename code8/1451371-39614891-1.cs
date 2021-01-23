        private static string T_MT4_HOST = "188.120.127.95";
        private static int T_MT4_PORT = 80;
        public static string MQ_Query(string query)
        {
            var i = 0;
            IPAddress[] IPs = Dns.GetHostAddresses(T_MT4_HOST);            
            var s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(IPs, T_MT4_PORT);            
            s.Send(Encoding.ASCII.GetBytes(String.Format("W{0}\nQUIT\n", query));
            var received = new byte[128];
            string ret = "";
            while (i<100)
            {
                
                s.Receive(received);
                var r = Encoding.ASCII.GetString(received);
                if (r.StartsWith("end\r\n"))
                    break;
                ret += r;
                i++;
            }
            
            s.Close();
            return ret;
        }

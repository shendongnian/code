    using System.Threading;
    using System.Threading.Tasks;
    
    
            public void Start(string ip)
            {
                Task.Factory.StartNew(() =>
               {
                    // If the method receieves a ping reply...
                    string response;
                   if (PingHostSweep(ip))
                   {
                        // Returns 192.168.0. + i + ACTIVE
                        response = ip + " ACTIVE";
                   }
                   else
                   {
                       response = ip + " CLOSED";
                   }
                   this.Invoke((MethodInvoker)(() => { textBox1.AppendText("\r\n" + response); }));
    
               });
            }
    
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                for (int i = 1; i <= 255; i++)
                {
                    Start(String.Format("192.168.100.{0}", i));
                }
            }

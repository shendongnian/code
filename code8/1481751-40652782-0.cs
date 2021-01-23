    using System;
    using System.Windows.Forms;
    using System.Net.Sockets;
    using System.Net;
    using System.Linq;
    
    namespace Server_App
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                backgroundWorker1.WorkerReportsProgress = true;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Loopback, 1234); //configure host
                backgroundWorker1.RunWorkerAsync(ep); //called to start a process on the worker thread and send argument (listener) to our workerprocess.
            }
    
            private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            {
                IPEndPoint ep = e.Argument as IPEndPoint;
                TcpListenerEx listener = new TcpListenerEx(ep);
                if (!listener.Active)
                {
                    listener.Start();
                }
                while (true)
                {
                    const int byteSize = 1024 * 1024;
                    byte[] message = new byte[byteSize];
                    using (var s = listener.AcceptTcpClient())
                    {
                        s.GetStream().Read(message, 0, byteSize);//obtaining network stream and receiving data through .Read()
                        message = cleanMessage(message);
                        string g = System.Text.Encoding.UTF8.GetString(message);
                        backgroundWorker1.ReportProgress(0, g);
                    }
                }
            }
    
            private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
            {
                textBox1.AppendText(Environment.NewLine + ">> " + e.UserState);
            }
    
            private byte[] cleanMessage(byte[] rawMessageByte)
            {
                byte[] cleanMessage = rawMessageByte.Where(b => b != '\0').ToArray();
                return cleanMessage;
            }
        }
    }

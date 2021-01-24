    using System;
    using System.Windows.Forms;
    using System.Text;
    using System.Net.Sockets;
    using System.Threading;
    namespace ChatClientForms
    {
        public partial class Form1 : Form
        {
            System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();
            NetworkStream serverStream = default(NetworkStream);
            string readData = null;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox3.Text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                readData = "Conected to Chat Server ...";
                msg();
                clientSocket.Connect("127.0.0.1", 8888);
                serverStream = clientSocket.GetStream();
    
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox1.Text + "$");
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();
    
                Thread ctThread = new Thread(getMessage);
                ctThread.Start();
            }
    
            private void getMessage()
            {
                while (true)
                {
                    serverStream = clientSocket.GetStream();
                    int buffSize = 0;
                    byte[] inStream = new byte[100025];
                    buffSize = clientSocket.ReceiveBufferSize;
                    serverStream.Read(inStream, 0, buffSize);
                    string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                    readData = "" + returndata;
                    msg();
                }
            }
    
            private void msg()
            {
                if (this.InvokeRequired)
                    this.Invoke(new MethodInvoker(msg));
                else
                    textBox2.Text = textBox2.Text + Environment.NewLine + " >> " + readData;
            }
    
        }
    }

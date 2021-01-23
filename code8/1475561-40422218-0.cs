    using System;
    using System.Threading;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Collections;
    
    namespace TCPClient
    {
	class TCPClient
	{
	
		[STAThread]
		static void Main(string[] args)
		{
			TCPClient client = null;
			client = new TCPClient("filename");
			
		}
		private String m_fileName=null;
		public TCPClient(String fileName)
		{
			m_fileName=fileName;
			Thread t = new Thread(new ThreadStart(ClientThreadStart));
			t.Start();
		}
		private void ClientThreadStart()
		{
			Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp );
			clientSocket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"),31001));
			// Send some data if erquired.
			clientSocket.Send(Encoding.ASCII.GetBytes("testdata"));
			
			// Receive the data whenver available.
            while(1)
            {
            Sleep(1000); //You can set time interval here if required.
			byte [] data = new byte[128];
			clientSocket.Receive(data);
			int length=BitConverter.ToInt32(data,0);
            }
			clientSocket.Close();
		}
	}
}

    public class NetworkUtils{
		//Client
		TcpClient client = null;
		int port = 40555;
		string serverIpAddress = "127.0.0.1";
		public Mutex mut = new Mutex();
		int byteToExpecting = 0;
		int savedBufferOffset = 0;
		Byte[] saveDataBuffer = new Byte[20000];
		NetworkStream stream;
		public string ServerIpAddress
		{
			get { return serverIpAddress; }
			set { serverIpAddress = value;}
		}
		string lastSentMsg = String.Empty;
		public string LastSentMsg
		{
			get { return lastSentMsg; }
			set { lastSentMsg = value;}
		}
		//Server
		string clientMsg = String.Empty;
		public string ClientMsg
		{
			get { return clientMsg; }
		}
		public void ClearClientMsg()
		{
			clientMsg = String.Empty;
		}
		TcpListener server=null;
		private string errMsg = String.Empty;
		public string ErrMsg
		{
			get { return errMsg; }
			set { errMsg = value;}
		}
		void ConnectToServer()
		{
			client = new TcpClient(serverIpAddress, port);	
		}
		public bool ClientSendMsg(string message)
		{
			try{
				ConnectToServer();
				
				Byte[] lengthByteArr = IntToByteArr(message.Length);
				client.GetStream().Write(lengthByteArr, 0, lengthByteArr.Length);
				Byte[] data = Encoding.ASCII.GetBytes(message);
				client.GetStream().Write(data, 0, data.Length);
				client.GetStream().Close();
			}
			catch (Exception e) 
			{
				errMsg = e.Message;
			}
			return errMsg.Length == 0;
		}
		public bool LaunchServer() {
			try {
				IPAddress localAddr = IPAddress.Parse("127.0.0.1");
				server = new TcpListener(localAddr, port);
				server.Start();
				ListenToClients();
			}
			catch(Exception e)
			{
				server.Stop();
			}
			return errMsg.Length == 0;
		}
		void ProcessInformation(IAsyncResult result)
		{
			try{
				TcpClient client;
				client = server.EndAcceptTcpClient(result);
				stream = client.GetStream();
				stream.BeginRead(saveDataBuffer, 0, sizeof(Int32), new AsyncCallback(callbackGetHeadrer), null);
				ListenToClients ();
			}
			catch(Exception e)
			{
				errMsg = e.Message;
				server.Stop();
			}
		}
		void callbackGetHeadrer (IAsyncResult asyncResult) { 
			int lenToRead = stream.EndRead(asyncResult);
			savedBufferOffset = 0;
			byteToExpecting = ByteArrToInt (saveDataBuffer);
			saveDataBuffer = new byte[byteToExpecting];
			stream.BeginRead (saveDataBuffer, 0, byteToExpecting, callback, null);
		}
		void callback (IAsyncResult asyncResult) { 
			int lenToRead = stream.EndRead(asyncResult);
			byteToExpecting -= lenToRead;
			savedBufferOffset += lenToRead;
			/*No one is gurentee that the 'lenToRead' will be correspanding to NetworkStream.Write execution order.
			We need to keep read from the stream until we will get waht we are expecting accrding 'byteToExpecting'
			So here we are keep calling 'stream.BeginRead'.*/
			if (byteToExpecting > 0) {
				stream.BeginRead (saveDataBuffer, savedBufferOffset, byteToExpecting, callback, null);
			} 
			else{
				mut.WaitOne();
				clientMsg = System.Text.Encoding.ASCII.GetString(saveDataBuffer,0, saveDataBuffer.Length);
				mut.ReleaseMutex();
				savedBufferOffset = 0;
				stream.Close();
				client.Close();
			}
		}
		bool ListenToClients()
		{
			try{
				server.BeginAcceptTcpClient( new AsyncCallback( ProcessInformation), server);
			}
			catch(Exception e)
			{
				errMsg = e.Message;
				server.Stop();
			}
			return errMsg.Length == 0;
		}
		public Byte[] IntToByteArr(Int32 intValue)
		{
			byte[] intBytes = BitConverter.GetBytes(intValue);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(intBytes);
			return intBytes;
		}
		public Int32 ByteArrToInt(Byte[] intByteArr)
		{
			Int32 Int32_NUM_OF_BYTES = 4;
			Byte[] buffer = new Byte[Int32_NUM_OF_BYTES];
			for (int i = 0; i < Int32_NUM_OF_BYTES; ++i)
				buffer [i] = intByteArr [i];
			
			if (BitConverter.IsLittleEndian)
				Array.Reverse (buffer);
			return BitConverter.ToInt32 (buffer, 0);
		}
	}

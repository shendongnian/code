        protected override void OnCreate(Bundle bundle)
        {
			...
            OpenButton.Click += delegate
            {
                SendCommand('O');
                ThreadPool.QueueUserWorkItem(o => ShutDown());
            };
			...
		}
		
		
		async void SendCommand(Char Command)
        {
			... //Command not used in this part of code
			const string sn = "SEND_NONCE";
            byte[] data = System.Text.Encoding.ASCII.GetBytes(sn);
            
            Client client = new Client();
            TcpClientPacket TheData = new TcpClientPacket(sn.Length);
            TheData.Buffer = data;
            TheData.Length = sn.Length;
            bool IsConnected = await client.InitializeAsync(HostUrl, Port);
			...
			
            await client.WriteAsync(TheData);
            TcpClientPacket TheResponse = await client.ReadAsync(16);
			...
			
		}
		
		
        public class Client
        {
            private TcpClient tcpClient;
            public async Task <bool> InitializeAsync(string ip, int port)
            {
                tcpClient = new TcpClient();
                try
                {
                    await tcpClient.ConnectAsync(ip, port);
                }
                catch
                {
                    return false;
                }
                return tcpClient.Connected;
            }
            public void Deactivate()
            {
                tcpClient.Close();
            }
            public async Task WriteAsync(TcpClientPacket Data)
            {
                var ns = tcpClient.GetStream();
                await ns.WriteAsync(Data.Buffer, 0, Data.Length);
            }
            public async Task<TcpClientPacket> ReadAsync(int ExpectedLength)
            {
                var ns = tcpClient.GetStream();
                TcpClientPacket Result = new TcpClientPacket(ExpectedLength);
                Result.Length = await ns.ReadAsync(Result.Buffer, 0, ExpectedLength);
                return Result;
            }
        }
		
		public class TcpClientPacket
        {
            public byte[] Buffer;
            public int Length;
            public TcpClientPacket(int Size)
            {
                Buffer = new byte[Size];
                Length = 0;
            }
        }
 

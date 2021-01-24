    class Program
	{
		static readonly ConcurrentQueue<byte[]> ReceivedPacketQueue = new ConcurrentQueue<byte[]>();
		static IPEndPoint _ipEndPoint = new IPEndPoint(IPAddress.Parse("192.168.4.142"), 2222);
		static int sendIter = 0;
		static int recvIter = 0;
		static void Main(string[] args)
		{
			var client = new UdpClient
			{
				ExclusiveAddressUse = false,
				Client = { ReceiveBufferSize = 8192 }
			};
			client.Client.Bind(_ipEndPoint);
			client.BeginReceive(OnUdpData, client);
			
			var message = new byte[100];
			int numberOfPackets;
			for (numberOfPackets = 0; numberOfPackets < 100; numberOfPackets++)
			{
				client.Send(message, message.Length, _ipEndPoint);
				Thread.Sleep(1);
				sendIter++;
			}
			Console.WriteLine(sendIter);
			Console.WriteLine(recvIter);
			Console.ReadKey();
		}
		static void OnUdpData(IAsyncResult result)
		{
			var socket = result.AsyncState as UdpClient;
			var message = socket.EndReceive(result, ref _ipEndPoint);
			ReceivedPacketQueue.Enqueue(message);
			recvIter++;
			socket.BeginReceive(OnUdpData, socket);
		}
	}

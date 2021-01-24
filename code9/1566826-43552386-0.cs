	public void readData()
	{
		Byte[] data;
		Int32 port = 51236;
		TcpClient client = new TcpClient("192.168.0.70", port);
		NetworkStream stream = client.GetStream();
		String responseData = String.Empty;
		try
		{
			while (true)
			{
				data = new Byte[256];  //arbitrary length for now
				// String to store the response ASCII representation.
				// Read the first batch of the TcpServer response bytes.
				Int32 bytes = stream.Read(data, 0, data.Length);
				if (bytes == 0){
					System.Threading.Thread.Sleep(1000);
				}
				else {
					responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
					m_upcCode = responseData;
				}
			}
		}
		catch (ArgumentNullException ArgEx)
		{
			m_upcCode = "ArgumentNullException: {0}" + ArgEx.Message.ToString();
		}
		catch (SocketException exSocket)
		{
			m_upcCode = "SocketException: {0}" + exSocket.Message.ToString();
		}
	}

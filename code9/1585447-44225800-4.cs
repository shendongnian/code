	public static void Main(string[] args)
	{
		using (TcpClient client = new TcpClient("62.210.130.212", 35025))
		using (NetworkStream networkStream = client.GetStream())
		{
			byte[] usernameBytes = Encoding.ASCII.GetBytes("This is just a test bro!");
			networkStream.Write(usernameBytes, 0, usernameBytes.Length);
			networkStream.Flush();
		}
        while (true) { } // loop infinitely
	}

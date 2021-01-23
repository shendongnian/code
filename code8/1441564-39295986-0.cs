	public static void Main()
	{
        SerialPort SendSerialPort = new SerialPort("Com3", 9600);
        SerialPort ReceiveSerialPort = new SerialPort("Com4", 9600);
		StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
		Thread readThread = new Thread(Read);
		// Set the read/write timeouts
		_serialPort.ReadTimeout = 500;
		_serialPort.WriteTimeout = 500;
        SendSerialPort.Open();
        ReceiveSerialPort.Open();
		_continue = true;
		readThread.Start();
		Console.Write("Name: ");
		name = Console.ReadLine();
		Console.WriteLine("Type QUIT to exit");
		while (_continue)
		{
			message = Console.ReadLine();
			if (stringComparer.Equals("quit", message))
			{
				_continue = false;
			}
			else
			{
				SendSerialPort.WriteLine(
					String.Format("<{0}>: {1}", name, message));
			}
		}
		readThread.Join();
		SendSerialPort.Close();
	}
	public static void Read()
	{
		while (_continue)
		{
			try
			{
				string message = ReceiveSerialPort.ReadLine();
				Console.WriteLine(message);
			}
			catch (TimeoutException) { }
		}
	}

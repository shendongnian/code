	var encoding = System.Text.Encoding.Unicode;
	var message = "I am new in serial port. Currently my project is to extract data from machine.";
	using (var ms = new MemoryStream(encoding.GetBytes(message)))
	{
		var bytes = new List<byte>();
		var buffer = new byte[23];
		var bytesRead = ms.Read(buffer, 0, buffer.Length);
		while (bytesRead > 0)
		{
			Console.WriteLine(encoding.GetString(buffer, 0, bytesRead));
			bytes.AddRange(buffer.Take(bytesRead));
			bytesRead = ms.Read(buffer, 0, buffer.Length);
		}
		Console.WriteLine(encoding.GetString(bytes.ToArray(), 0, bytes.Count));
	}

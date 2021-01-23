	using (var br = new BinaryReader(File.OpenRead(path)))
	{
		br.BaseStream.Position = 0x1D;
		byte[] bytes = br.ReadBytes(4);
		
		for (int i = 0; i < 4; i++)
		{
			bytes[i] = (byte)(bytes[i] ^ 149);
		}
		
		textBox1.Text = new string(bytes.Select(Convert.ToChar).ToArray());
	}

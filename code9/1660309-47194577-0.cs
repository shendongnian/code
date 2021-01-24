	public static void Main()
	{
		string data = "%B3%F3%C7%F9";
		byte[] bData = new byte[data.Length / 3];
		for (int i = 0; i < data.Length; i += 3)
		{
			int pos = i / 3;			
			bData[pos] = Convert.ToByte(data.Substring(i + 1, 2), 16);
		}
		data = System.Text.Encoding.GetEncoding("euc-kr").GetString(bData);
		Console.WriteLine(data);
	}

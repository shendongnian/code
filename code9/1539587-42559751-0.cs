	var b = new byte[256];
	for (int i = 0; i < 256; i++)
		b[i] = (byte)i;
    var encoding = System.Text.Encoding.GetEncoding(437);
    var s = encoding.GetString(b);
	var b2 = encoding.GetBytes(s);
	for (int i = 0; i < 256; i++)
		if (b2[i] != i)
			Console.WriteLine("Error at " + i);

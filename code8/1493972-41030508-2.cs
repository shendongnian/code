	string hexString = "YourEncodedHexString";
	List<string> findhex = hexString.Split(new string[] { "&#", ";" }, StringSplitOptions.RemoveEmptyEntries).ToList();
	StringBuilder sb = new StringBuilder();
	foreach(string st in findhex)
	{
		if(st.Substring(0, 1) == "x")
		{
			string hs = st.Substring(1, 2);
			sb.Append(Convert.ToChar(Convert.ToUInt32(hs, 16)));
		}
		else
		{
			sb.Append(st);
		}
	}
	String ascii = sb.ToString();
	Console.WriteLine(ascii);

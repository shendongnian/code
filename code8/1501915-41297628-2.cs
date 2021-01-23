	string subtitle = @"1
	00:00:40,152 --> 00:00:43,614
	Out west there was this fella,
	2
	00:00:43,697 --> 00:00:45,824
	fella I want to tell you about,";
	List<string> timestrings = new List<string>();
	List<string> splittedtimestrings = new List<string>();
	List<string> splittedstring = subtitle.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries ).ToList();
	foreach(string st in splittedstring)
	{
		if(st.Contains("00"))
		{
			timestrings.Add(st);
		}
	}
	foreach(string s in timestrings)
	{
		string[] foundstr =  s.Split(new string[] { " --> " }, StringSplitOptions.RemoveEmptyEntries);
		splittedtimestrings.Add(foundstr[0]);
		splittedtimestrings.Add(foundstr[1]);
	}

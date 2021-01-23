    DateTime d;
    foreach (string s in ss)
    {
    	if (DateTime.TryParse(ss[1], out d))
    	{
    		Console.WriteLine(d.ToString("yyyy-MM-dd HH:mm:ss"));
    	}
    }

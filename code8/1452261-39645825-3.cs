    DateTime d;
    foreach (string s in ss)
    {
    	if (DateTime.TryParse(s, out d))
    	{
    		Console.WriteLine(d.ToString("yyyy-MM-dd HH:mm:ss"));
    	}
    }

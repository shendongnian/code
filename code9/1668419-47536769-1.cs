	public void AppendFile(string filePath, long firstWord, long lastWord)
	{            
	    using (StreamWriter sw = File.AppendText(filePath))
	    {
	        for (long i = firstWord; i < lastWord; i++)
	        {
	            sw.WriteLine(GetWord(i));
	
	        }
	
	    }
	
	}
	
	public void AppendFile(string filePath, long lastWord)
	{
	    AppendFile(filePath, 0, lastWord);
	
	}
	
	public void AppendFile(string filePath)
	{
	    AppendFile(filePath, long.MaxValue);
	
	}
	
	public static string GetWord(long i)
	{
	    string s = Encoding.ASCII.GetString(new byte[] { (byte)(i % 256) });
	    if (i < 256)
	        return s;
	    return GetWord(i / 256) + s;
	
	}

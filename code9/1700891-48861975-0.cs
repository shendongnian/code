    private string ReadLastLine(string fileName, int maximumLineLength)
    {
		string lastLine = string.Empty;
        using(Stream s = File.OpenRead(path))
        {
		    s.Seek(-maximumLineLength, SeekOrigin.End);
	
		    using(StreamReader sr = new StreamReader(s))
	        {
				string line;
	
				while((line = sr.ReadLine()) != null)
				{
					lastLine = line;
				}
            }
        }
        return lastLine;
    }

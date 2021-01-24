    public enum SizeType
    {
    	Actual = 1024,
    	Factory = 1000
    }
    
    public string GetSize(double len, SizeType sizeType)
    {
    	string[] sizes = { "B", "KB", "MB", "GB", "TB" };
    	int order = 0;
    	while (len >= (int)sizeType && order < sizes.Length - 1)
    	{
    		order++;
    		len = len / (int)sizeType;
    	}
    	return String.Format("{0:0.##} {1}", Math.Floor(len), sizes[order]);
    }

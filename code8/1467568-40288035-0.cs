    private const ushort FirebirdFlag = 0x8000;
    
    private void DispObsVersinoFromBinary(string path)
    {
    	using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    	{
    		int fileSize = (int)fs.Length;
    		byte[] buf = new byte[1024];
    		fs.Read(buf, 0, 1024);
    		var obsHex = string.Join("", buf.Skip(0x12).Take(2).Select(x => x.ToString("X2")).Reverse());
    		var minor = string.Join("", buf.Skip(0x40).Take(2).Select(x => x.ToString("X2")).Reverse());
    		Console.WriteLine($"ODSVer:{Convert.ToInt32(obsHex, 16) & ~FirebirdFlag}");
    		Console.WriteLine($"ODSMinorVer:{Convert.ToInt32(minor, 16)}");
    	}
    }

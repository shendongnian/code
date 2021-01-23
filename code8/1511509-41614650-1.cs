    public String GetHash(string fFile)
    {
    	var sb = new StringBuilder();
    	using (var md5 = MD5.Create())
    	{
    		using (var fStream = File.OpenRead(fFile))
    		{
    			string Hash = BitConverter.ToString(md5.ComputeHash(fStream));
    			for (int i = 0; i < hash.Length; i++)
    			sb.Append(hash[i].ToString("X2"));
    
    			fStream.Close();
    		}
    	}
    	return sb.ToString();
    }
    public bool Compare(string hash1, string hash2)
    {
    	return Regex.Replace(hash1, @"\s+", "") == Regex.Replace(hash2, @"\s+", "");
    }

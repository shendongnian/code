    public static unsafe List<float> LoadToList(byte[] bytes)
    	{
    		var list = new List<float>();
    		var step = sizeof (float);
    		for (int i = 0; i < bytes.Length; i += step)
    		{
    			fixed (byte* pbyte = &bytes[i])
    			{
    				list.Add(*((float*)pbyte));
    			}
    		}
    
    		return list;
    	}

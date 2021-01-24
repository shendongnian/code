      public static string CreateDirectory(string path, int i)
        {
    		if (i>0)
    		{
    			if (Directory.Exists(path + $" ({i})"))
    				return CreateDirectory(path,++i);
    			else
    			{
    				Directory.CreateDirectory(path + $" ({i})"));
    				return path + $" ({i})";
                }
    		}
    		else
    			if (!Directory.Exists(path))
                {
    				Directory.CreateDirectory(path);
    				return path;
                }
    			else
    				return CreateDirectory(path,1);    
        }

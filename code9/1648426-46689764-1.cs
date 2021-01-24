		    		List<string> lines = new List<string>();
        List<string> lines2 = new List<string>();
		
		
		
        try
        {
            StreamReader reader = new StreamReader(System.IO.File.OpenRead(pad));
            StreamReader read = new StreamReader(System.IO.File.OpenRead(pad2));
			
            string line;
            string line2;
			
			//With this you can change the cells you want to compair
			int comp1 = 1;
			int comp2 = 1;
			
            while ((line = reader.ReadLine()) != null && (line2 = read.ReadLine()) != null)
            {			
                string[] split = line.Split(Convert.ToChar(seperator));
                string[] split2 = line2.Split(Convert.ToChar(seperator));
                if (line.Contains(seperator) && line2.Contains(seperator))
                {
                    if (split[comp1] != split2[comp2])
                    {
                        //It is not the same
                    }
                    else
                    {
                        //It is the same
                    }
                }
            }
            reader.Dispose();
            read.Dispose();
        }
        catch
        {
        }

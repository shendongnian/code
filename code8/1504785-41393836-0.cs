        List<String> lines = new List<String>();
        using (StreamReader reader = new StreamReader(System.IO.File.OpenRead(@"C:\Test\test.CSV"));)
        {
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.Contains(","))
                {
                    String[] split = line.Split(',');
    
                    if (//condition for Edit record like : split[1] == "abc" etc.)
                    {
                        // update that 
                        split[1] = "xyz";
                        line = String.Join(",", split);
                        lines.Add(line);
                    }
                    if (//condition for Delete row.)
                    {
                        // don't add that row into string list
                    }
                }
    
            }
        }
    
        using (StreamWriter writer = new StreamWriter(@"C:\Test\test.CSV", false))
        {
            foreach (String line in lines)
                writer.WriteLine(line);
        }

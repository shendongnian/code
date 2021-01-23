    public dynamic Read(string file)
    {
        using (var streamReader = new StreamReader(File.OpenRead(file))
        {
            while ((var line = streamReader.ReadLine()) != null)
            {
                if (line.StartsWith("| CAM", StringComparison.OrdinalIgnoreCase)) 
                {
                    var columns = line.Split('|').Select(x => x.Trim());
       
                    // Parse the values here, put them in a DTO
                }
            }
        }
    }

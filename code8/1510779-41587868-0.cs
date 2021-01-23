    public Dictionary<int, string> ReadIniFile(string filePath)
    {
        Dictionary<int, string> result = new Dictionary<int, string>();
        using ( StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open))
        {
            string line = string.Empty;
            while( ( line = reader.ReadLine() ) != null )
            {
                if(line.Contains('='))
                {
                    int eCode = 0;
                    if( int.TryParse(line.Split('=')[0], out eCode) )
                    {
                        result.Add(eCode, line.Split('=')[1]);
                    }
                }
            }
        }
        return result;
    }

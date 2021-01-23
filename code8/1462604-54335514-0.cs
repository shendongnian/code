        Dictionary<string, string> _werFileContent = 
        new Dictionary<string, string>();
        using (StreamReader sr = new StreamReader(Path))
                    {
    
                        string _line;
                        while ((_line = sr.ReadLine()) != null)
                        {
                            string[] keyvalue = _line.Split('=');
                            if (keyvalue.Length == 2)
                            {
                                _werFileContent.Add(keyvalue[0], keyvalue[1]);
                            }
                        }

    private Dictionary<string, string> LoadFile(string path)
            {
                string line;
                Dictionary<string, string> vals = new Dictionary<string, string>();
                using (StreamReader file = new StreamReader(path))
                {
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        vals.Add(parts[0], parts[1]);
                    }
                }
                return vals;
            }
    

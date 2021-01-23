    public string[][] csvToArray (string filePath)
            {
                string line = null;
                var result = new List<string[]>();
                using (var sr = new StreamReader(filePath))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        if(string.IsNullOrWhiteSpace(line)) continue;
                        result.Add(sr.Split(','));
                    }
                }
                return result.ToArray();
            }

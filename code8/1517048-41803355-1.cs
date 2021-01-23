    public int[][] csvToArray (string filePath)
            {
                string line = null;
                var result = new List<int[]>();
                using (var sr = new StreamReader(filePath))
                {
                    while((line = sr.ReadLine()) != null)
                    {
                        if(string.IsNullOrWhiteSpace(line)) continue;
                        result.Add(sr.Split(',').Select(x=> string.IsNullOrWhiteSpace(x) ? 0 : int.Parse(x)).ToArray());
                    }
                }
                return result.ToArray();
            }

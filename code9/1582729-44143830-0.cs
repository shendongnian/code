    private List<string> getGoldenHashes(string xml)
        {
            List<string> list = new List<string>();
            int i = 0;
            XDocument doc = XDocument.Load(xml);
            var goldHashes = doc.Descendants("MD5GoldenHash");
            foreach (var gh in goldHashes)
            {
                list.Add(gh.Value.ToString());                
            }
            return list;
        }

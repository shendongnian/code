    class Program
    {
        static void Main(string[] args)
        {
            string path = @"data.xml";
            // An XmlReader created from a file on the disk or any stream like web request for example
            using (var reader = XmlReader.Create(path))
            {
                foreach (var item in GetRecords(reader))
                {
                    Debug.WriteLine(string.Join(", ", item.Select(i => string.Format("{0}={1}", i.Key, i.Value))));
                }
            }
        }
        private static IEnumerable<Dictionary<string, string>> GetRecords(XmlReader reader)
        {
            Dictionary<string, string> record = null; 
            while (reader.Read())
            {
                if (reader.IsStartElement() && reader.LocalName == "Series")
                {
                    record = new Dictionary<string, string>();
                    while (reader.MoveToNextAttribute())
                    {
                        record.Add(reader.LocalName, reader.Value);
                    }
                }
                else if (reader.IsStartElement() && reader.LocalName == "Obs")
                {                   
                    while (reader.MoveToNextAttribute())
                    {
                        record.Add(reader.LocalName, reader.Value);
                    }
                    yield return record;
                }
            }
        }
    }

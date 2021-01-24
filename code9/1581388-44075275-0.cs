    private Dictionary<string, UnicodeMap> _unicodeMap;
    void ReadMap()
    {
            var engine = new FileHelperAsyncEngine<UnicodeMap>();
            using (engine.BeginReadFile(MapFile))
            {
                foreach (var record in engine)
                {
                      _unicodeMap.Add(record.Letter.Trim(), record); //Added .Trim()
                }
            }
    }

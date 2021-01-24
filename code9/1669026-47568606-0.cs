    class QueryEntry
    {
        public string Type { get; set; }
        public string Key { get; set; }
        public string Operators { get; set; }
        public string Value { get; set; }
        public List<QueryEntry> Group { get; private set; }
        public bool IsGroup { get { return Group.Count > 0; } }
        public QueryEntry()
        {
            Group = new List<QueryEntry>();
        }
    }

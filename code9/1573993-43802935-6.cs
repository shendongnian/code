    interface IRecord
    {
        List<string> Tracks { get; set; }
    }
    class RecordA : IRecord
    {
        public List<string> Tracks { get; set; }
        public int Speed { get; set; }
    }
    class RecordB : IRecord
    {
        public List<string> Tracks { get; set; }
        public int Size { get; set; }
    }

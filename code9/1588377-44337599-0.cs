    public class Record
    {
        public int Underline { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
    }
    public class RecordGroup
    {
        public int Id { get; set; }
        public Record Header { get; set; }
        public Record SubHeader { get; set; }
        public List<Record> DataList { get; set; }
    }

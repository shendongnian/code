    public class TableEntry
    {
        public int pkiNotesLineEntriesId { get; set; }
        public int fkiAccountId { get; set; }
        public int fkiNotesColumnId { get; set; }
        public string Value { get; set; }
        public bool isNewEntry { get; set; }
    }

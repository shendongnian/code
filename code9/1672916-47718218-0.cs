    public class NoteDto 
    {
        public string Date { get; set; }
        public string Time { get; set; }
        public string Author { get; set; }
        public string NoteText { get; set; }
        [XmlIgnore]
        public string Project { get; set; }
    }

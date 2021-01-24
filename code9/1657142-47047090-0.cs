    public class JobNote
    {
        public string NoteText { get; set; }
        public string NoteType { get; set; }
    }
    public class ListJob
    {
        public int JobNumber { get; set; }
        public object Asset { get; set; }
        public List<JobNote> JobNotes { get; set; }
    }

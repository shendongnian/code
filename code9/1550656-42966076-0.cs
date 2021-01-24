    public class FootViewModel
    {
        public SubjectViewModel Subject { get; set; }
        public List<ContactValueViewModel> ContactValues{ get; set; }
    }
    public class ContactValueViewModel
    {
        public SubjectContactInfoViewModel SubjectContactInfo { get; set; }
        public InfoTypeViewModel InfoTypes { get; set; }
    }

    public class Dialog
    {
        private readonly static _instance = new Dialog();
        public static Instance { get { return _instance; }}
        public List<Participant> Participants { get; set; }
    }

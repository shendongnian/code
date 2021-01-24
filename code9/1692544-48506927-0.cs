    [Serializable]
    public class EventErrorList
    {
        public int transmiter { get; set; }
        public List<EventEntry> events { get; set; }
    }
    [Serializable]
    public class EventEntry
    {
        public string msg { get; set; }
        public string source { get; set; }
    }

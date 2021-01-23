    public class Metrics
    {
        public int blocks { get; set; }
        public int bounce_drops { get; set; }
        public int bounces { get; set; }
        public int clicks { get; set; }
        public int deferred { get; set; }
        public int delivered { get; set; }
        public int invalid_emails { get; set; }
        public int opens { get; set; }
        public int processed { get; set; }
        public int requests { get; set; }
        public int spam_report_drops { get; set; }
        public int spam_reports { get; set; }
        public int unique_clicks { get; set; }
        public int unique_opens { get; set; }
        public int unsubscribe_drops { get; set; }
        public int unsubscribes { get; set; }
    }
    
    public class Stat
    {
        public string type { get; set; }
        public string name { get; set; }
        public Metrics metrics { get; set; }
    }
    
    public class RootObject
    {
        public string date { get; set; }
        public List<Stat> stats { get; set; }
    }

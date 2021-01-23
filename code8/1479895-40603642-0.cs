    class LogEntry
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Post { get; set; }
        public override string ToString()
        {
            return "Date: " + Date.ToLongDateString() + " Kl: " + Date.ToShortTimeString()
                + "\tTitle: " + Title + "\tPost: " + Post;
        }
    }

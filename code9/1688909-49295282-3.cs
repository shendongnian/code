    public class Posting
    {
        public long Id { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }
        public DateTime PostingDate { get; set; }
        public virtual User User { get; set; }
    }

    public class ColList
    {
        public string Date { get; set; }
        public string Id { get; set; }
        public int BId { get; set; }
        public int Time { get; set; }
        public int Talk { get; set; }
        public string Status { get; set; }
        public override string ToString()
        {
            return $"{Date}\t{Id}\t{BId}\t{Time}\t{Talk}\t{Status}";
        }
    }

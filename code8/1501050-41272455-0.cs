    public class YearStats
    {
        public int Year { get; set; }
        public IList<int> Months { get; set; }
        public YearStats()
        {
            Months = new List<int>();
        }
    }

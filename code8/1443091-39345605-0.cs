    public enum Month
    {
        January,
        February,
        // and so on...
        December
    }
    public class TotalAmounts
    {
        public TotalAmounts()
        {
            Months = new Dictionary<Month, int>();
        }
        public Dictionary<Month, int> Months { get; set; }
    }

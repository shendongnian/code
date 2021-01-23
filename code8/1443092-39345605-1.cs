    public enum Month
    {
        January,
        February,
        // and so on...
        December
    }
    public class Amounts
    {
        public Amounts()
        {
            Months = new Dictionary<Month, int>();
        }
        public Dictionary<Month, int> Months { get; set; }
    }

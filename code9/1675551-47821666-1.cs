    public class MonthClass
    {
        public ReadOnlyCollection<string> Months { get; } = new List<string>(12)
        {
            "January", "February", "March", "April","May","June","July",
            "August","September", "October", "November","December"
        }.AsReadOnly();
    }

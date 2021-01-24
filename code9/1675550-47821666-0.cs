    public class MonthClass
    {
        private readonly ReadOnlyCollection<string> _months = new List<string>(12)
        {
            "January", "February", "March", "April","May","June","July",
            "August","September", "October", "November","December"
        }.AsReadOnly();
        public ReadOnlyCollection<string> GetMonths() => _months;
    }

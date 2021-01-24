    public class PocoObject
    {
        public string DateString { get; set; }
        public DateTime Date
        {
            get
            {
                DateTime date;
                return DateTime.TryParseExact(DateString, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date) ? date : DateTime.MinValue;
            }
        }
    }

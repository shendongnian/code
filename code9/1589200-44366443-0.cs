    public class DateWithOrWithoutTime
    {
        public Date? DateWithoutTime { get; private set; }
        public DateTime? DateWithTime { get; private set; }
        public DateWithOrWithoutTime(Date dateToSet)
        {
            DateWithoutTime = dateToSet;
        }
        public DateWithOrWithoutTime(DateTime dateTimeToSet)
        {
            DateWithTime = dateTimeToSet;
        }
        public bool IsDate()
        {
            return DateWithoutTime != null;
        }
        public bool IsDateTime()
        {
            return DateWithTime != null;
        }
    }

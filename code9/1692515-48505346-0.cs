    public class DateTimeProviderDouble : IDateTimeProvider
    {
        public DateTimeProviderDouble(DateTime provides)
        {
            Now = provides;
        }
        public DateTime Now { get; private set; }
    }
   
    var dateTimeProvider = new DateTimeProviderDouble(DateTime.Parse("6/21/2018"));

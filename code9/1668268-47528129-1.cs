    public class DateTimeRangeAtt : RangeAttribute
        {
            public DateTimeRangeAtt()
              : base(typeof(DateTime),
                    new DateTime(1, 1, 1920).ToShortDateString(),
                    new DateTime(1, 1, DateTime.Now.Year-18).ToShortDateString())
            { }
        }
    
    [DateTimeRangeAtt]
    public DateTime dateOfBirth { get; set; }

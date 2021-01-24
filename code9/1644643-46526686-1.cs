    public class MyCultureInfo : CultureInfo
    {
        ......implement constructors       
        private DateTimeFormatInfo dateTimeFormatInfo;
        public override DateTimeFormatInfo DateTimeFormat {
            get
            {
                if (dateTimeFormatInfo == null)
                {
                    var dateTimeFormatInfo = new DateTimeFormatInfo();
                    dateTimeFormatInfo.FullDateTimePattern = "yyyy-MM-ddTHH:mm:ssK";
                    dateTimeFormatInfo.LongTimePattern = "yyyy-MM-ddTHH:mm:ssK";
                }
                return dateTimeFormatInfo;
            }
        }
    }

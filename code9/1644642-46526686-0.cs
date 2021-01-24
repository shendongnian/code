    public class MyCultureInfo : CultureInfo
    {
        ......implement constructors       
        public override DateTimeFormatInfo DateTimeFormat {
            get
            {
                var myFormat = new DateTimeFormatInfo();
                myFormat.FullDateTimePattern = "yyyy-MM-ddTHH:mm:ssK";
                myFormat.LongTimePattern = "yyyy-MM-ddTHH:mm:ssK";
                return myFormat;
            }
        }
    }

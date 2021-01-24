     public class ParsedDate
            {
                public int day   { get; set; }
                public int month { get; set; }
                public int year  { get; set; }
            }
    
            public ParsedDate ParseDate(string inputString)
            {
                DateTime outDate;
                ParsedDate returnObject = new ParsedDate();
                if (String.IsNullOrEmpty(inputString))
                {
                    throw new ArgumentException("String can not be empty");
                }
    
                DateTime.TryParse(inputString, out outDate);
    
                if (outDate != null)
                {
                    returnObject = new ParsedDate
                    {
                        day = outDate.Day,
                        month = outDate.Month,
                        year = outDate.Year
                    };
                }
                return returnObject;
            }

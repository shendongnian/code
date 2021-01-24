      public static string DateTimeFormatter(this string possibleDatetime, string format)
            {
                
                DateTime result;
                if( DateTime.TryParse(possibleDatetime, out result))
                {
                   return result.ToString(format);
                }
    
                return possibleDatetime;
            }

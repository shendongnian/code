    public static List<String> Days
        {
            var dtf = new DateTimeFormatInfo();
            dtf.FirstDayOfWeek = DayOfWeek.Monday;
            dtf = CultureInfo.CurrentCulture.DateTimeFormat;
            
            var abbDayNames = dtf.AbbreviatedDayNames;
            var days = new string[7];
            
            for(int i=0; i<7; i++)
            {
                days[i] = abbDayNames[((int)dtf.FirstDayOfWeek + i) % 7];
            }
            return new List<string>(days);
        }

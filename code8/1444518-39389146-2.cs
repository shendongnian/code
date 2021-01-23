        public static List<String> Days
        {
            var abbDayNames = CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames;
            
            var days = new string[7];
            var firstDayOfWeek = (int)DayOfWeek.Monday;
            for (int i = 6; i>= 0; i--)
            {
                days[i] = abbDayNames[(firstDayOfWeek + i) % 7];
            }
            return new List<string>(days);
        }

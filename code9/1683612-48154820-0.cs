            CultureInfo culture = new CultureInfo("en-Us");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            var myDate = new DateTime(2016, 7, 4, 12, 0, 0);
            string month = culture.TextInfo.ToTitleCase(dtfi.GetMonthName(myDate.Month));
            string dayOfWeek = culture.TextInfo.ToTitleCase(dtfi.GetDayName(myDate.DayOfWeek));
            string fullDate = $"{dayOfWeek}, {month} {myDate.Day}, {myDate.Year}";
            Console.Write(fullDate);

        public static TimeSpan ConvertToAMPM(DateTime date)
        {
            return TimeSpan.Parse(date.ToString("h:mm tt", 
            CultureInfo.InvariantCulture));
        }
        public static TimeSpan ConvertTo24Hour(string time)
        {
            var cultureSource = new CultureInfo("en-US", false);
            var cultureDest = new CultureInfo("de-DE", false);
            var dt = DateTime.Parse(time, cultureSource);
            return TimeSpan.Parse(dt.ToString("t", cultureDest));
        }

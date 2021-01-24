        public static DateTime Combine(DateTime date, string time, string timeZone)
        {
            TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(TimezoneDictionary[timeZone]);
            var timeOfDay = DateTime.ParseExact(time, "h:mm tt", null).TimeOfDay;
            var combined = date.Add(timeOfDay).Subtract(tzInfo.BaseUtcOffset);
            if (tzInfo.IsDaylightSavingTime(combined))
                combined = combined.Subtract(TimeSpan.FromHours(1));
            return combined;
        }

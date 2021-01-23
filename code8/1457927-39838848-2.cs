    public static bool DayMinuteEqual(this string otherDate)
        {
            // We have to strip out the "." character if present (e.g. 2:05 P.M.)
            DateTime otherDateObj = DateTime.Parse(otherDate.Replace(".", ""));
            return DateTime.Now.ToString("hh:mm tt") == otherDateObj.ToString("hh:mm tt");
        }

    public string ConvertToVCalendarDateString(DateTime d)
        {
            d = d.ToUniversalTime();
            string yy = d.Year.ToString();
            string mm = d.Month.ToString("D2");
            string dd = d.Day.ToString("D2");
            string hh = d.Hour.ToString("D2");
            string mm2 = d.Minute.ToString("D2");
            string ss = d.Second.ToString("D2");
            string s = yy + mm + dd + "T" + hh + mm2 + ss + "Z"; // Pass date as vCalendar format YYYYMMDDTHHMMSSZ (includes middle T and final Z) '
            return s;
        }

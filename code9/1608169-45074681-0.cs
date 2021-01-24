    public static class ExtensionMethods
    {
       public static string GetPersianDate(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            return string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), 
                   jc.GetMonth(date), jc.GetDayOfMonth(date));
          }
    }

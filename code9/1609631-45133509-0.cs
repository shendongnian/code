    public static string ToString(DateTime? date, string format)
    {
       if (date.HasValue)
          return String.Format("{0:}"+format, date);
       else return "";
    }

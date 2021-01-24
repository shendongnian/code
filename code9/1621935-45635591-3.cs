    protected string FormatTime(object timeValue)
    {
       if (Convert.IsDBNull(timeValue))
       {
          return "";
       }
       else
       {
          TimeSpan asTime = (TimeSpan)timeValue;
          DateTime asDate = Convert.ToDateTime(asTime.ToString());
          string time = asDate.ToString("%h:mmtt");
          return time;
        }
     }

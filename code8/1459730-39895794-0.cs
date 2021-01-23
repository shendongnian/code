    public static string GetISO8601OffsetForThisMachine()
    {
        string MethodResult = null;
        try
        {
            TimeSpan OffsetTimeSpan = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
            string Offset = (OffsetTimeSpan < TimeSpan.Zero ? "-" : "+") + OffsetTimeSpan.ToString(@"hh\:mm");
            MethodResult = Offset;
        }
        catch //(Exception ex)
        {
            //ex.HandleException();
        }
        return MethodResult;
    }

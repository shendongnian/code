    class Stackoverflow
        {
            static void FormatDate(string strInputDateTimeValue)
            {
                int day = 0;
                int month = 0;
                int year = 0;
                int hours = 0;
                int minutes = 0;
                int seconds = 0;
                int milliSeconds = 0;
                int dateTimeKind = 0;
    
                if (!string.IsNullOrEmpty(strInputDateTimeValue))
                {
                    List<string> lstSplittedInputDateTime = strInputDateTimeValue.Split(' ').ToList();
                    if (lstSplittedInputDateTime != null)
                    {
                        lstSplittedInputDateTime = (from data in lstSplittedInputDateTime
                                                    where !string.IsNullOrEmpty(data)
                                                    select data).ToList();
    
                        if (lstSplittedInputDateTime.ElementAtOrDefault<string>(0) != null)
                        {
                            string strDate = lstSplittedInputDateTime[0];//Fetching Only Date Part: Considering date format will be mm/DD/yyyy
                            if (!string.IsNullOrEmpty(strDate))
                            {
                                List<string> lstSplittedDate = strDate.Split('/').ToList();
                                if (lstSplittedDate != null)
                                {
                                    if (lstSplittedDate.ElementAtOrDefault<string>(1) != null) 
                                        month = Convert.ToInt32(lstSplittedDate[1]);//Fetch Month
    
                                    if (lstSplittedDate.ElementAtOrDefault<string>(0) != null)
                                        day = Convert.ToInt32(lstSplittedDate[0]);//Fetch Day
    
                                    if (lstSplittedDate.ElementAtOrDefault<string>(2) != null)
                                        year = Convert.ToInt32(lstSplittedDate[2]);//Fetch Year
                                }
                            }
                        }
    
                        if (lstSplittedInputDateTime.ElementAtOrDefault<string>(1) != null)
                        {
                            string strTime = lstSplittedInputDateTime[1];//Fetching Only Time Part
                            if (strTime != null)
                            {
                                List<string> lstSplittedTime = strTime.Split(':').ToList();
                                if (lstSplittedTime != null)
                                {
                                    if (lstSplittedTime.ElementAtOrDefault<string>(0) != null)
                                        hours = Convert.ToInt32(lstSplittedTime[0]);//Fetch Hours
    
                                    if (lstSplittedTime.ElementAtOrDefault<string>(1) != null)
                                        minutes = Convert.ToInt32(lstSplittedTime[1]);//Fetch Minutes
    
                                    if (lstSplittedTime.ElementAtOrDefault<string>(2) != null)
                                        seconds = Convert.ToInt32(lstSplittedTime[2]);//Fetch Seconds
    
                                    if (lstSplittedTime.ElementAtOrDefault<string>(3) != null)
                                        milliSeconds = Convert.ToInt32(lstSplittedTime[3]);//Fetch MilliSeconds
                                }
                            }
                        }
    
                        if (lstSplittedInputDateTime.ElementAtOrDefault<string>(2) != null)
                        {
                            string strDateTimeKind = lstSplittedInputDateTime[2];//Fetching DateTimeKind
                            if (strDateTimeKind != null)
                            {
                                if (strDateTimeKind.ToLower() == "utc")
                                    dateTimeKind = (int)System.DateTimeKind.Utc;
                                else if (strDateTimeKind.ToLower() == "Local")
                                    dateTimeKind = (int)System.DateTimeKind.Local;
                                else
                                    dateTimeKind = (int)System.DateTimeKind.Utc;
                            }
                        }
                    }
    
                    DateTime dtFormattedDate = new DateTime(year, month, day, hours, minutes, seconds, (DateTimeKind)dateTimeKind);
    
                    
                    Console.WriteLine("Local: {0}", TimeZoneInfo.ConvertTime(dtFormattedDate, TimeZoneInfo.Local).ToString());
                    Console.WriteLine("UTC: {0}", TimeZoneInfo.ConvertTime(dtFormattedDate, TimeZoneInfo.Utc).ToString());
                }
            }
    
            static void Main(string[] args)
            {
                FormatDate("27/06/2017  16:11:00 UTC");
    	    Console.ReadLine();
    	}
    }

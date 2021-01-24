    static void FormatDate(string strInputDateTimeValue)
            {
                int day = 0, month = 0, year = 0, hours = 0, minutes = 0, seconds = 0, milliSeconds = 0, dateTimeKind = 0;
                List<string> lstSplittedInputDateTime = (from data in strInputDateTimeValue.Split(' ').ToList() where !string.IsNullOrEmpty(data) select data).ToList();
                if (lstSplittedInputDateTime != null)
                {
                    string strDate = lstSplittedInputDateTime[0];//Fetching Only Date Part: Considering date format will be mm/DD/yyyy
                    if (!string.IsNullOrEmpty(strDate))
                    {
                        month = Convert.ToInt32(strDate.Split('/').ToList()[1]);//Fetch Month
                        day = Convert.ToInt32(strDate.Split('/').ToList()[0]);//Fetch Day
                        year = Convert.ToInt32(strDate.Split('/').ToList()[2]);//Fetch Year
                    }
                    string strTime = lstSplittedInputDateTime[1];//Fetching Only Time Part
                    if (strTime != null)
                    {
                        hours = Convert.ToInt32(strTime.Split(':').ToList()[0]);//Fetch Hours
                        minutes = Convert.ToInt32(strTime.Split(':').ToList()[1]);//Fetch Minutes
                        seconds = Convert.ToInt32(strTime.Split(':').ToList()[2]);//Fetch Seconds
                        milliSeconds = Convert.ToInt32(strTime.Split(':').ToList()[3]);//Fetch MilliSeconds
                    }
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
                DateTime dtFormattedDate = new DateTime(year, month, day, hours, minutes, seconds, (DateTimeKind)dateTimeKind);
                Console.WriteLine("Local: {0}", TimeZoneInfo.ConvertTime(dtFormattedDate, TimeZoneInfo.Local).ToString());
                Console.WriteLine("UTC: {0}", TimeZoneInfo.ConvertTime(dtFormattedDate, TimeZoneInfo.Utc).ToString());
            }
    
            public void Run()
            {
                FormatDate("27/06/2017  16:11:00 UTC");
                Console.ReadLine();
            }

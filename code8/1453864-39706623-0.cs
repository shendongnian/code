    string strCurrDate = (DateTime.Now.Date + currBlock.EndTime).ToString();
                            DateTime dtYourDate = DateTime.Parse((DateTime.Now.AddDays(-1).Date + currBlock.StartTime).ToString());
                            string strYourDate = dtYourDate.ToShortDateString() + " " + dtYourDate.ToLongTimeString();
                            string strTotalMinsElapsed = TotalMinutesElapsed(dtYourDate).ToString();
    
    
    
     private long TotalMinutesElapsed(DateTime dtYourDate)
            {
                long lTotalMinutesElapsed = 0;
    
                //Find Current Date and Time
                DateTime dtCurrent = DateTime.Now;
    
                //Find Time Difference details between current date and your given date
                TimeSpan tsDiff = dtCurrent.Subtract(dtYourDate);
    
                //Add Total Minutes for Days difference
                lTotalMinutesElapsed = lTotalMinutesElapsed + tsDiff.Days * (24 * 60);
    
                //Add Total Minutes for Hour difference
                lTotalMinutesElapsed = lTotalMinutesElapsed + tsDiff.Hours * 60;
    
                //Add Minutes 
                lTotalMinutesElapsed = lTotalMinutesElapsed + tsDiff.Minutes;
    
                return lTotalMinutesElapsed;
            }

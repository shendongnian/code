    private List<string> GetDateDropDownList()// get rid of parameter
    {
      List<string> dateList= new List<string>(); // inside method
        DateTime dt = DateTime.Now;
        for (int i = 1; i <= 18; i++)
        {
            dt = dt.AddMonths(-1);
            var month = dt.ToString("MMMM");
            var year = dt.Year;
             dateList.Add(String.Format("{0}-{1}", month, year));
         }
         return dateList;
       }

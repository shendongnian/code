    //Help Method to iterate over Dates
    public IEnumerable<DateTime> EachMonth(DateTime from, DateTime thru)
    {
        for(var month = from.Date; month.Date <= thru.Date; month = month.AddMonth(1))
            yield return month;
    }
    
    DataTable dt = new DataTable();
    dt.Columns.Add("SessionID").DataType = typeof(Int32);
    dt.Columns.Add("SessionDate").DataType = typeof(DateTime);
    
    //Iterate all Dates from 01.01.2015 to 01.03.2017
    foreach (DateTime date in EachMonth(new DateTime(2015,1,1), new DateTime(2017,3,1))
    {
       DataRow row = dt.NewRow();
       //Check if the magic Date is reached. After this ID jumps to 70
       if (date.CompareTo(new DateTime(2016, 2, 28)) <= 0)
       {
          row["SessionID"] = 50;
       }
       else
       {
          row["SessionID"] = 70;
       }
       row["SessionDate"] = date;
       dt.Rows.Add(row);
    }

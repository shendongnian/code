    DateTime date;
    PersianCalendar pc = new PersianCalendar();
    foreach(DataRow row in dt.Rows)
    {
       date = row.Field<DateTime>("dateEnter");
       string datePC = string.Format("{0}/{1}/{2}", 
                       pc.GetYear(date), pc.GetMonth(date), pc.GetDayOfMonth(date));
       row.SetField<string>("pcDate", datePC);
    }

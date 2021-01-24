    DataTable yourTable = new DataTable();
    //Fill with strange strings like 'created at 2017-01-01'
    yourTable.Columns.Add("RealDate");
    
    foreach (DataRow row in yourTable.Rows)
    {
       //Instead of substr you can also use regex if you prefer
       row["RealDate"] = Convert.ToDateTime(Substring(row["DateColumn"], 10, 10));
    }

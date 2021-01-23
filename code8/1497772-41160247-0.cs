     DataTable dt = new DataTable("Customers");
     dt.Columns.Add("BirtDate", typeof(DateTime));
     dt.Columns.Add("BirtDateLong", typeof(long));
    
     for(int i=0;i<10;i++)
     {
         DataRow drow = dt.NewRow();
         drow["BirtDateLong"] = 636173924284229875;
         dt.Rows.Add(drow);
     }
     
    
     IEnumerable<DataRow> rows = dt.Rows.Cast<DataRow>();
     rows.ToList().ForEach(r => r.SetField("BirtDate", new DateTime(Convert.ToInt64(r["BirtDateLong"]))));

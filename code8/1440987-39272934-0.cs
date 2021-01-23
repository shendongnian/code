     DataTable dt = new DataTable();
     dt.Columns.Add("dateColumn");
     DataRow row = dt.NewRow();
     row[0] = "01-12-2016";
     dt.Rows.Add(row);
    
     int year = 2016;            
     DataRow[] foundAuthors = dt.AsEnumerable().Where(r => DateTime.Parse(r.Field<string>("dateColumn")).Year == year).ToArray();

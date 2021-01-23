    DataTable dt = new DataTable();
    dt.Columns.Add("PId", typeof(Int32));
    dt.Columns.Add("PName", typeof(string));
    dt.Columns.Add("Qty", typeof(Int32));
    dt.Rows.Add(123, "XYZ", 2);
    dt.Rows.Add(223, "ABC", 4);
    dt.Rows.Add(434, "PQR", 33);
        
    DataView dataView = dt.DefaultView;
    dataView.Sort = "PName";
    DataTable DtSorted = dataView.ToTable();
                    

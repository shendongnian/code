        DataTable dt = new DataTable();
        dt.Columns.Add("PId", typeof(Int32));
        dt.Columns.Add("PName", typeof(string));
        dt.Columns.Add("Qty", typeof(Int32));
        dt.Rows.Add(123, "XYZ", 2);
        dt.Rows.Add(223, "ABC", 4);
        dt.Rows.Add(434, "PQR", 33);
    
        var stkLists = dt.AsEnumerable().ToList();
        var matchList = stkLists.Where(m => m["PName"].ToString().StartsWith("PQR")).ToList();
        var FinalList = matchList.Concat(stkLists.Except(matchList).ToList());

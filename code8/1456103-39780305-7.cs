        DataSet ds = new DataSet();
        DataTable dt = ds.Tables["YOURDATATABLE"];
        IEnumerable<DataRow> firstHundred = dt.AsEnumerable().Take(100);
        // create datatable from query
        DataTable boundTable = firstHundred.CopyToDataTable<DataRow>();
        //call your web service with 1st hundred
        //
        IEnumerable<DataRow> nextHundred = dt.AsEnumerable().Skip(100).Take(100);
        // and so on
        boundTable = nextHundred.CopyToDataTable<DataRow>();
        //call your web service with 1st hundred
        //

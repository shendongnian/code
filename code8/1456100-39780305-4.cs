        DataSet ds = new DataSet();
        DataTable dt = ds.Tables["YOURDATATABLE"];
        IEnumerable<DataRow> firstHundred = dt.AsEnumerable().Take(100);
        // call your web service with 1st hundred
        int skipCount = 0;
    
        for (int i = 1; i <= 45; i++)
        {
            skipCount += 100;
            IEnumerable<DataRow> nextHundred = dt.AsEnumerable().Skip(skipCount).Take(100);
            // call web service with next hundred and so on
        }

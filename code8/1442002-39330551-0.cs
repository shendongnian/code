    DataTable dtTable = new DataTable();
            dtTable.Columns.Add(new DataColumn("pass", typeof(int)));
    
    
            for (int i = 0; i < 100; i++)
            {
                DataRow drRow = dtTable.NewRow();
                drRow["pass"] = (i + 1) % 10;
                dtTable.Rows.Add(drRow);
            }
    
            var query = (from row in dtTable.AsEnumerable()
                         group row by row.Field<int>("pass") into passes
                         orderby passes.Key, passes.Count() ascending
                         select new
                         {
                             pass = passes.Key,
                             passCount = passes.Count()
                         });
    
            DataTable dtTableSorted = new DataTable();
            dtTableSorted.Columns.Add(new DataColumn("pass", typeof(int)));
            dtTableSorted.Columns.Add(new DataColumn("passCount", typeof(int)));
    
            query.ToList().ForEach(x =>
            {
                DataRow drRow = dtTableSorted.Rows.Add(x.pass, x.passCount);
            });

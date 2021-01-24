    public void DtSelect()
        {
            var dt = new DataTable();
            var columns = Enumerable.Range(1, 10).Select(x => "Col" + x).ToList();
            columns.ForEach(x => dt.Columns.Add(x));
            Enumerable.Range(1, 1000).ToList().ForEach(x =>
             {
                 var row = dt.NewRow();
                 if (x % 15 == 0) columns.ForEach(z => row[z] = x);
                 dt.Rows.Add(row);
             });
            var query = string.Join(" is not null and ", columns) + " is not null";
            var nonEmpty = dt.Select(query).CopyToDataTable();
   
        }

     DataTable my_datatable = new DataTable();
     my_datatable.Columns.Add("Value", typeof(int));
     my_datatable.Columns.Add("Type", typeof(string));
     my_datatable.Rows.Add(1, "Normal");
     my_datatable.Rows.Add(1, "Normal");
     my_datatable.Rows.Add(2, "SQL");
     my_datatable.Rows.Add(2, "SQL");
     my_datatable.Rows.Add(3, "CSS");
     my_datatable.Rows.Add(4, "UNICODE");
     my_datatable.Rows.Add(4, "UNICODE");
     my_datatable.Rows.Add(4, "UNICODE");
     var distinctIds = my_datatable.AsEnumerable()
                   .Select(s => new {
                       value = s.Field<int>("value"),
                   })
                   .Distinct().ToList();
      int total = distinctIds.Sum(item => item.value);

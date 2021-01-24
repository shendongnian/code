    DataTable dt = new DataTable();
    dt.Columns.Add("column1");
    dt.Columns.Add("value1", typeof(int));
    dt.Columns.Add("value2", typeof(int));
    dt.Rows.Add("ee", 1, 2);
    dt.Rows.Add("ee", 2, 4);
    dt.Rows.Add("ee1", 3, 6);
    dt.Rows.Add("ee2", 3, 3);
    dt.Rows.Add("ee2", 4, 2);
    var items = dt.AsEnumerable().GroupBy(
                x => x.Field<string>("column1")
        ).Select
        (
            n => new
            {
                column1 = n.Key,
                value1 = n.Sum(z => z.Field<int>("value1")),
                value2 = n.Sum(z => z.Field<int>("value2"))
            }
        )
        .ToList();

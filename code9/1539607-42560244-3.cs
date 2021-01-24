    DataTable dt = new DataTable();
    dt.Columns.Add("Col");
    dt.Rows.Add("A");
    dt.Rows.Add("B");
    dt.Rows.Add("C");
    dt.Rows.Add("F");
    dt.Rows.Add("G");
    var lists = new List<Tuple<string, int>>()
    {
        Tuple.Create("D", 3), Tuple.Create("E", 4)
    };

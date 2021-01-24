    var dt = new DataTable();
    dt.Columns.Add("label");
    dt.Columns.Add("Size", typeof(int));
    dt.Columns.Add("Improvement", typeof(double));
    
    dt.Rows.Add(new object[] { "a", 256, -26.05 });
    dt.Rows.Add(new object[] { "b", 512, -646.13 });
    dt.Rows.Add(new object[] { "c", 768, -38.96 });
    dt.Rows.Add(new object[] { "d", 1024, 0 });
    dt.Rows.Add(new object[] { "e", 1280, 1.13 });
    dt.Rows.Add(new object[] { "f", 1536, 1.34 });
    dt.Rows.Add(new object[] { "g", 1792, 1.34 });
    dt.Rows.Add(new object[] { "h", 2048, 1.34 });

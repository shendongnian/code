    var dt = new DataTable();
    dt.Columns.Add("Id", typeof(int));
    dt.Columns.Add("val1", typeof(int));
    dt.Columns.Add("val2", typeof(string));
    dt.Rows.Add(1, 1, "a");
    dt.Rows.Add(2, 20, "b");
    dt.Rows.Add(3, 300, "c");
    dt.Rows.Add(4, 4000, "d");
    Console.WriteLine(string.Join("\n", dt.Select().Select(row => string.Format("{0}\t{1}\t{2}", row["Id"], row["val1"], row["val2"]))));
 

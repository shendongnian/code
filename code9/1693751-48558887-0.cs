    DataTable dt = new DataTable();
    DataColumn col = new DataColumn("test");
    col.DataType = System.Type.GetType("System.String");
    dt.Columns.Add(col);
    
    string[] lines = File.ReadAllLines("C:\\Users\\aaaaa\\Desktop\\aaaaa.txt");
    foreach (var line in lines)
    {
        var segments = line.Split(';');
        foreach (var seg in segments)
        {
            DataRow dr = dt.NewRow();
            dr[0] = seg;
            dt.Rows.Add(dr);
        }
    }

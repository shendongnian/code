    DataTable dt = new DataTable();
    string[] lines = File.ReadAllLines("C:\\Users\\abc\\Desktop\\abc.txt");
    var firstLine = lines.First();
    var columns = firstLine.Split(';');
    
    for (var icount = 0; icount < columns.Count(); icount++)
    {
        var colName = columns[icount].Contains(":") ? columns[icount].Split(':')[0] : "Column" + icount;
        var dataCol = new DataColumn(colName);
        dataCol.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(dataCol);
    }
    
    foreach (var line in lines)
    {
        DataRow dr = dt.NewRow();
        var segments = line.Split(';');
        for (var icount = 0; icount < segments.Count(); icount++)
        {
            var colVal = segments[icount].Contains(":") ? segments[icount].Split(':')[1] : "";
            dr[icount] = colVal;
        }
        dt.Rows.Add(dr);
    }

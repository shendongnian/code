    public DataTable DTforReport()
    {
        DataTable dt = new DataTable();
        string[] lines = File.ReadAllLines("C:\\Users\\abc\\Desktop\\abc.txt");
        DataRow dr = dt.NewRow();
        for (int i = 0; i < lines.Length; i++)
        {
            DataColumn col = new DataColumn(lines[i].Split(':')[0]);
            col.DataType = Type.GetType("System.String");
            dt.Columns.Add(col);
            var segment = lines[i].Split(':')[1];               
            dr[i] = segment;                
        }
        dt.Rows.Add(dr);
        return dt;
    }

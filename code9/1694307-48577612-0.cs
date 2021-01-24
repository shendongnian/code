    public DataTable DTforReport()
        {
            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines("C:\\Users\\abc\\Desktop\\abc.txt");
            var columns = lines[0].Split(';');
            for (int l = 0; l < columns.Length; l++)
            {
                DataColumn col = new DataColumn(columns[l].Split(':')[0]);
                col.DataType = Type.GetType("System.String");
                dt.Columns.Add(col);
            }
            foreach (var line in lines)
            {
                var segments = line.Split(';');
                for (int i = 0; i < segments.Length; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr[i] = segments[i].Split(':')[1];
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

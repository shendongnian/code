    DataTable dt = new DataTable(); //Your datasource
    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = "csv file (*.csv)|*.csv";
    sfd.FileName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_R";
    if (sfd.ShowDialog() == DialogResult.OK)
    {
        using (StreamWriter sw = new StreamWriter(sfd.FileName))
        {
            //Add Column Headers
            foreach (var col in dt.Columns.Cast<DataColumn>())
            {
                sw.Write($"{col.ColumnName},");
            }
            sw.Write("\r\n");
            //Add Rows
            foreach (var row in dt.AsEnumerable().Select(r => r.ItemArray.Cast<string>()))
            {
                foreach (var cell in row)
                {
                    sw.Write($"{cell},");
                }
                sw.Write("\r\n");
            }
        }
    }

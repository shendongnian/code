    DataTable dt = new DataTable(); //Your datasource
    SaveFileDialog sfd = new SaveFileDialog();
    sfd.Filter = "csv file (*.csv)|*.csv";
    sfd.FileName = DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + "_R";
    if (sfd.ShowDialog() == DialogResult.OK)
    {
        using (StreamWriter sw = new StreamWriter(sfd.FileName))
        {
            //Add Column Headers
            sw.Write(string.Join(",", dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName)));
            sw.Write(",\r\n");
            //Add Rows
            foreach (var row in dt.AsEnumerable().Select(r => r.ItemArray.Cast<string>()))
            {
                sw.Write(string.Join(",", row));
                sw.Write(",\r\n");
            }
        }
    }

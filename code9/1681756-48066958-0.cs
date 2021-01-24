    public bool SaveToCSV(DataTable dt, string FileName)
    {
        try
        {
            var lines = new List<string>();
    
            string[] columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
    
            var header = string.Join(",", columnNames);
            lines.Add(header);
    
            //New Code Starts Here
            List<string> zeroList = new List<string>();
            for(int i = 0; i < columnNames.Count; i++){
                zeroList.Add("0");
            }
    
            lines.AddRange(zeroList);
            //New Code Ends Here
    
            var valueLines = dt.AsEnumerable()
                               .Select(row => string.Join(",", row.ItemArray));
            lines.AddRange(valueLines);
    
            File.WriteAllLines(FileName, lines);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message.ToString());
            return false;
        }   
    }

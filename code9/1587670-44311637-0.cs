    private void button1_Click(object sender, EventArgs e)
    {
        DataTable table = new DataTable();
        table.Columns.Add("HeaderInfo");
        table.Columns.Add("Model Name");
        table.Columns.Add("Serial Number");
        table.Columns.Add("Send Date");
        table.Columns.Add("Total Counter");
        table.Columns.Add("Total Color Counter");
        table.Columns.Add("Total Black Counter");
        table.Columns.Add("Total Scan/Fax Counter");
        table.Columns.Add("Operating Accumulation Time");
        table.Columns.Add("Energizing Accumulation Time");
        table.Columns.Add("Standing Accumulation Time");
        table.Columns.Add("Power Saving Accumulation Time");
        var rowData = table.NewRow();
        var filePath = @"c:\public\temp\temp.txt";
        foreach (var line in File.ReadAllLines(filePath)
            .Where(l => !string.IsNullOrWhiteSpace(l)))
        {
            var thisLine = line.Trim();
            if (thisLine.StartsWith("eof", StringComparison.OrdinalIgnoreCase))
            {
                // We've reached the end of a block, so add this row to our table
                table.Rows.Add(rowData);
                rowData = table.NewRow();
            }
            else if (thisLine.StartsWith("from", StringComparison.OrdinalIgnoreCase))
            {
                // This line doesn't contain the built in column name, so I made one up
                rowData["HeaderInfo"] = thisLine;
            }
            else
            {
                var firstComma = thisLine.IndexOf(',');
                var columnName = thisLine.Substring(0, firstComma).Replace("[", "").Replace("]", "");
                rowData[columnName] = thisLine.Substring(firstComma + 1);
            }                               
        }
        dataGridView1.DataSource = table;
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
    }  

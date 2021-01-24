    using (var csvFileWriter = new StreamWriter(CsvFpath, false))
    {
        // Write all the column headers, joined with a ','
        csvFileWriter.WriteLine(string.Join(",",
            stockGridView.Columns.Cast<DataGridViewColumn>().Select(col => col.HeaderText)));
        // Grab all the rows that aren't new and, for each one, join the cells with a ','
        foreach (var row in stockGridView.Rows.Cast<DataGridViewRow>()
            .Where(row => !row.IsNewRow))
        {
            csvFileWriter.WriteLine(string.Join(",",
                row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value.ToString())));
        }
    }

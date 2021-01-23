         string csv = string.Empty;
 
    //Add the Header row for CSV file.
    foreach (DataGridViewColumn column in dataGridView4.Columns)
    {
        csv += column.HeaderText + ',';
    }
 
    //Add new line.
    csv += "\r\n";
 
    //Adding the Rows
    foreach (DataGridViewRow row in dataGridView4.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            //Add the Data rows.
            csv += cell.Value.ToString().Replace(",", ";") + ',';
        }
 
        //Add new line.
        csv += "\r\n";
    }
 
    //Exporting to CSV.
    string folderPath = txt_csv_exp_path.Text;
    File.WriteAllText(folderPath +txt_exp_file_name.Text +" .csv", csv);
    MessageBox.Show("CSV file saved.");

    private void btnMergeFile_Click(object sender, RoutedEventArgs e)
    {
        ExcelFile workbook = new ExcelFile();
    
        // Copy all sheets into a resulting ExcelFile.
        foreach (string file in this.listBox1.SelectedItems)
        {
            ExcelFile temp = ExcelFile.Load(file);
            foreach (ExcelWorksheet sheet in temp.Worksheets)
                workbook.Worksheets.AddCopy(
                    // Unique sheet name.
                    string.Format("{0} - {1}", System.IO.Path.GetFileNameWithoutExtension(file), sheet.Name),
                    // Sheet object.
                    sheet);
        }
    
        // Save ExcelFile.
        workbook.Save(this.newFileName.Text);
    }

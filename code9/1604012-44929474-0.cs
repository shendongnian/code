    // Select workbook
    var fileInfo = new FileInfo(@"yourfile.xlsx");
    // Load workbook
    using (var package = new ExcelPackage(fileInfo)) {
    // Itterate through workbook sheets
        foreach (var sheet in package.Workbook.Worksheets){
    // Itterate through each column until final column
            for (int i = 1; i <= sheet.Dimension.End.Column; i++) {
                comboBox1.Items.Add(sheet.Cells[1, i].Text);
            }
        }
    }

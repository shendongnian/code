    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string path = txtPath.Text;
        var workbook = new XLWorkbook(path);
        using (var worksheet = workbook.Worksheet(txtWorksheet.Text))
        {
            var cells = worksheet.Range(txtMinRange.Text+":"+txtMaxRange.Text).Cells();
            foreach (var c in cells)
            {
                if (c.Value == "")
                {
                    c.Value = "-";
                }
            }
        }
        workbook.SaveAs("RowCells.xlsx");
        workbook.Dispose();
    }
 

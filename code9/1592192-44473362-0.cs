    void OpenExcel()
    {
        xlexcel = new Excel.Application();
        
        xlexcel.Visible = true; //Tabelle ist Sichtbar
        
        // Datei öffnen
        xlWorkBook = xlexcel.Workbooks.Open("mypath");
        
        // store first selected sheet in variable
        xlWorkSheet =(Excel.Worksheet)xlWorkBook.Worksheets[comboBox1.SelectedText];
    }
    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // select new sheet and update variable to refer to it
        switch (comboBox1.Text)
        {
            case "Sheetname":
                xlWorkSheet = (Excel.Worksheet)(xlWorkBook.Sheets[1]);
                xlWorkSheet.Select();
                break;
            case "Scheetname":
                xlWorkSheet = (Excel.Worksheet)(xlWorkBook.Sheets[2]);
                xlWorkSheet.Select();
                break;
        }
    }
    private void button1_Click(object sender, EventArgs e) // Hier werden die daten eingetragen!
    {
        int lastRow = xlWorkSheet.Range["A" + xlWorkSheet.Rows.Count].End[Excel.XlDirection.xlUp].Row + 1;
        xlWorkSheet.Cells[lastRow, 1] = textBox1.Text;
        xlWorkSheet.Cells[lastRow, 2] = textBox2.Text;
        xlWorkSheet.Cells[lastRow, 3] = textBox2.Text;
    }

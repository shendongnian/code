    // storing Each row and column value to excel sheet  
    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++) {  
        for (int j = 0; j < dataGridView1.Columns.Count; j++) {  
            worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();  
        }  
    }  
    // save the application  
    workbook.SaveAs("c:\\output.xls", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);  
    // Exit from the application  
    app.Quit();  

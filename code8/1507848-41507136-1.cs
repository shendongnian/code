    private void btnSave_Click(object sender, EventArgs e) {
      //================================================
      //CODE TO EXPORT DATAGRID TO EXCEL======= ========
      //================================================    
      // Creating a Excel object. 
      Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
      Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
      Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
      excel.Visible = true;
      try {
        worksheet = workbook.ActiveSheet;
        
        worksheet.Name = "ExportedFromDatGrid";
        int cellRowIndex = 1;
        int cellColumnIndex = 1;
        int tableCol = -1;
        //Loop through each row and read value from each column. 
        for (int i = 0; i < dataGridView.Rows.Count; i++) {
          for (int j = 0; j < dataGridView.Columns.Count; j++) {
            // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check.
            tableCol = dataGridView.Columns[j].DisplayIndex;
            if (cellRowIndex == 1) {
              //worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView.Columns[j].HeaderText;
              worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView.Columns[tableCol].HeaderText;
            }
            else {
              //worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView.Rows[i].Cells[j].Value.ToString();
              worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView.Rows[i-1].Cells[tableCol].Value.ToString();
            }
            cellColumnIndex++;
          }
          cellColumnIndex = 1;
          cellRowIndex++;
        }
        //Getting the location and file name of the excel to save from user. 
        SaveFileDialog saveDialog = new SaveFileDialog();
        saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        saveDialog.FilterIndex = 2;
        if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
          workbook.SaveAs(saveDialog.FileName);
          MessageBox.Show("Export Successful");
        }
      }
      catch (System.Exception ex) {
        MessageBox.Show(ex.Message);
      }
      finally {
        excel.Quit();
        workbook = null;
        excel = null;
      }
    }

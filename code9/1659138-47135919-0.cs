    private void btnExportExcel_Click(object sender, EventArgs e)
    {
    	YourDataGridID.SelectAll();
    	DataObject dataObj = YourDataGridID.GetClipboardContent();
    	if (dataObj != null)
    		Clipboard.SetDataObject(dataObj);
    	GenerateExcel();
    }
    private static void GenerateExcel()
    {
    	Microsoft.Office.Interop.Excel.Application xlexcel;
    	Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    	Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    	object misValue = System.Reflection.Missing.Value;
    	xlexcel = new Microsoft.Office.Interop.Excel.Application();
    	xlexcel.Visible = true;
    	xlWorkBook = xlexcel.Workbooks.Add(misValue);
    	xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
    	Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)xlWorkSheet.Cells[1, 1];
    	CR.Select();
    	xlWorkSheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
    }

    private void btnexcel_Click(object sender, EventArgs e)
    {
        Dictionary<int,bool> dicSkip = new Dictionary<int,bool>();
        dicSkip[dgvColThree.Index] = true;
        dicSkip[dgvColFour.Index] = true;
       
        Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
        objexcelapp.Application.Workbooks.Add(Type.Missing);
        objexcelapp.Columns.ColumnWidth = 25;
    
        int colcount = 0;
    
        for (int i = 1; i < dgven.Columns.Count + 1; i++)
        {
            if (dicSkip.ContainsKey(i-1))
                continue;
    
            colcount++;
            objexcelapp.Cells[1, colcount] = dgven.Columns[colcount - 1].HeaderText;
        }
    
        /*For storing Each row and column value to excel sheet*/
    
        for (int i = 0; i < dgven.Rows.Count; i++)
        {
            colcount=0;
    
            for (int j = 0; j < dgven.Columns.Count; j++)
            {
                if (dicSkip.ContainsKey(j))
                   continue;
    
                colcount++;
    
                if (dgven.Rows[i].Cells[j].Value != null)
                {
                    objexcelapp.Cells[i + 2, colcount + 1] = dgven.Rows[i].Cells[j].Value.ToString();
                }
            }
        }
        string excelFilename = "Vendors";
        MessageBox.Show("Your excel file exported successfully at D:\\" + excelFilename + ".xlsx");
        objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + excelFilename + ".xlsx");
        objexcelapp.ActiveWorkbook.Saved = true; 
    }

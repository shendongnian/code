         private void button8_Click(object sender, EventArgs e)
          {
            Microsoft.Office.Interop.Excel.Application xlApp; //Declare the 
                     //Excel object
               try
               {
                 xlApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
               }
               catch (Exception ee)
               {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
               
               
                  if (xlApp == null)
                  {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                  }
                
                
                }
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }
   
            object misValue = System.Reflection.Missing.Value;
           
          Microsoft.Office.Interop.Excel.Workbook xlWorkBook=xlApp.Workbooks.Add(misValue);
        try
        {
          xlWorkBook = xlApp.Workbooks.Open(@"cross_check.xls");//,
           
        }
       catch (Exception ex)
       {
       
         ;//     
       }
           Microsoft.Office.Interop.Excel.Range range;
          
           Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = 
           (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
           int rownum = 1;
           int MAX_ROWS=30000; //You may define your own limit
           bool written = true;
           range = xlWorkSheet.UsedRange;
           while ((written) && (rownum<MAX_ROWS))
           {
             var test = (range.Cells[rownum, 1] as 
            Microsoft.Office.Interop.Excel.Range).Value2;
             if (test != null)
              {
                 rownum++;
              }
             else
              {
                written = false;
              }
            }
           if (written == false)
           {
             xlWorkSheet.Cells[rownum, 1] = comboBox2.Text;
             xlWorkSheet.Cells[rownum, 2] = textBox5.Text;
             xlWorkSheet.Cells[rownum, 3] = textBox2.Text;
             xlWorkSheet.Cells[rownum, 4] = comboBox3.Text;
             xlWorkSheet.Cells[rownum, 5] = textBox3.Text;
             xlWorkSheet.Cells[rownum, 6] = comboBox1.Text;
           }
            xlApp.DisplayAlerts = false; //Disables the prompts
            xlWorkBook.SaveAs(@"cross_check.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
            xlApp.DisplayAlerts = true; //
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            MessageBox.Show("Excel file created/updated succcessfully");
   
       }

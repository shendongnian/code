        ............
        public bool startd = false;
        public int rownum;
        public int MAX_ROWS = 30000;//You may define your own limit here
        public bool isFirstTime = true;
        public string oldBtnFileText;
        public string oldBtnDataText;
        public Microsoft.Office.Interop.Excel.Application xlApp;
        public Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        public Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        public Microsoft.Office.Interop.Excel.Range range;
        public object misValue;
        private void button8_Click(object sender, EventArgs e)
        {
            if (startd == false)
            {
                
                return;
            }
            if (isFirstTime == true)
            {
                bool written = true;
                int rnum = 1;
                if (xlWorkSheet!=null)
                {
                    range=xlWorkSheet.UsedRange;
                while ((written) && (rnum < MAX_ROWS))
                {
                    var test = (range.Cells[rnum, 1] as Microsoft.Office.Interop.Excel.Range).Value2;
                    if (test != null)
                    {
                        rnum++;
                    }
                    else
                    {
                        written = false;
                    }
                }
                if (written == false)
                {
                    rownum = rnum;
                    isFirstTime = false;
                }
                else
                {
                    MessageBox.Show("The current WorkSheet is Full");
                    return;
                }
            }
            }
            if (xlWorkSheet!=null)
            {
                xlWorkSheet.Cells[rownum, 1] =  comboBox2.Text;
                xlWorkSheet.Cells[rownum, 2] =  textBox5.Text;
                xlWorkSheet.Cells[rownum, 3] =  textBox2.Text;
                xlWorkSheet.Cells[rownum, 4] =  comboBox3.Text;
                xlWorkSheet.Cells[rownum, 5] =  textBox3.Text;
                xlWorkSheet.Cells[rownum, 6] =  comboBox1.Text;
                rownum++;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (startd == false)
            {
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
                misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                try
                {
                    xlWorkBook = xlApp.Workbooks.Open(@"cross_check.xls");//,
                }
                catch (Exception ex)
                {
                    ;//     
                }
                xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                oldBtnFileText = button9.Text.ToString();
                button9.Text = "File Ready to accept data";
                oldBtnDataText = button1.Text.ToString();
                button8.Text = "Enter Data";
                startd = true;
            }
            else
            {
                xlApp.DisplayAlerts = false;
                xlWorkBook.SaveAs(@"cross_check.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, misValue, misValue, misValue, misValue, misValue);
                xlApp.DisplayAlerts = true;
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkBook);
                Marshal.ReleaseComObject(xlApp);
                MessageBox.Show("Excel file created/updated succcessfully");
                startd = false;
                button9.Text = oldBtnFileText; //Restore the initial captions
                button8.Text = oldBtnDataText;//...
            }
        }
    //

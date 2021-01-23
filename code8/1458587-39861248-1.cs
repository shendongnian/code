    using Excel = Microsoft.Office.Interop.Excel;
        
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
            string str;
            int rCnt = 0;
            int cCnt = 0;
            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open("C:\\ExcelData\\DataToImp.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            for (int rowIndex = 1; rowIndex <= range.Rows.Count; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex <= range.Columns.Count; columnIndex++)
                {
                    Excel.Range rangeTest = range.Cells[rowIndex, columnIndex] as Excel.Range;
                    if (rangeTest.MergeCells)// && rangeTest.Value2 == null)
                    {
                        //continue;
                        int columns = rangeTest.Columns.Count;
                        columnIndex += columns;
                    }
                    MessageBox.Show("m " + (string)rangeTest.Value2);
                    
                }
            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();
            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

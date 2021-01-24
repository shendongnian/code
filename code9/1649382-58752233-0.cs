    class Program
    {
        static void Main(string[] args)
        {
            Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Open("YourPath", ReadOnly: true, Password: "PWD");
            Excel._Worksheet xlWorksheet = xlWorkBook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rCnt;
            int rw = 0;
            int cl = 0;
            //get the total column count
            cl = xlRange.Columns.Count;
            List<MyRow> myRows = new List<MyRow>();
            for (rCnt = 1; rCnt <= 1; rCnt++)
            {
                if (rCnt % 6 == 1)
                {//get rows which ABC or XYZ is in
                    for (int col = 2; col <= cl; col++)
                    {//traverse columns (the first column is not included)
                        for (int rowABCD = rCnt; rowABCD <= rCnt + 5; rowABCD++)
                        {//traverse the following four rows after ABC row or XYZ row
                            MyRow myRow = new MyRow();
                            //get ABC or XYZ
                            myRow.Col1 = (string)(xlRange.Cells[rowABCD, 1] as Range).Value2.ToString();
                            // get the  value of current column  in ABC row or XYZ row
                            myRow.Col2 = (string)(xlRange.Cells[rowABCD, col] as Range).Value2.ToString();
                            // add the newly created myRow to the list
                            myRows.Add(myRow);
                        }
                    }
                }
            }
            xlApp.Quit();
        }
        public class MyRow
        {
            public string Col1 { get; set; }
            public string Col2 { get; set; }
        }
    }

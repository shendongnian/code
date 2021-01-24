    private void button1_Click(object sender, EventArgs e) {
      Stopwatch sw = new Stopwatch();
      MessageBox.Show("Start DoExcel...");
      sw.Start();
      DoExcel();
      sw.Stop();
      MessageBox.Show("End DoExcel...Took: " + sw.Elapsed.Seconds + " seconds and " + sw.Elapsed.Milliseconds + " Milliseconds");
     }
    private void button2_Click(object sender, EventArgs e) {
      MessageBox.Show("Start DoExcel2...");
      Stopwatch sw = new Stopwatch();
      sw.Start();
      DoExcel2();
      sw.Stop();
      MessageBox.Show("End DoExcel2...Took: " + sw.Elapsed.Seconds + " seconds and " + sw.Elapsed.Milliseconds + " Milliseconds");
    }
    private void button3_Click(object sender, EventArgs e) {
      MessageBox.Show("Start DoExcel3...");
      Stopwatch sw = new Stopwatch();
      sw.Start();
      DoExcel3();
      sw.Stop();
      MessageBox.Show("End DoExcel3...Took: " + sw.Elapsed.Seconds + " seconds and " + sw.Elapsed.Milliseconds + " Milliseconds");
    }
    
    // object[,] array implementation
    private void DoExcel3() {
      textBox1.Text = "";
      string Path = @"D:\Test\Book1 - Copy.xls";
      Excel.Application xl = new Excel.Application();
      Excel.Workbook WB;
      Excel.Range rng;
      WB = xl.Workbooks.Open(Path);
      xl.Visible = true;
      int totalRows = 0;
      int totalCols = 0;
      foreach (Excel.Worksheet CurrentWS in WB.Worksheets) {
        rng = CurrentWS.UsedRange;
        totalCols = rng.Columns.Count;
        totalRows = rng.Rows.Count;
        object[,] objectArray = (object[,])rng.Cells.Value;
        for (int row = 1; row < totalRows; row++) {
          for (int col = 1; col < totalCols; col++) {
            if (objectArray[row, col] != null)
              textBox1.Text += objectArray[row,col].ToString();
          }
          textBox1.Text += Environment.NewLine;
        }
      }
      WB.Close(false);
      xl.Quit();
      Marshal.ReleaseComObject(WB);
      Marshal.ReleaseComObject(xl);
    }
    // Range taken out of loops
    private void DoExcel2() {
      textBox1.Text = "";
      string Path = @"D:\Test\Book1 - Copy.xls";
      Excel.Application xl = new Excel.Application();
      Excel.Workbook WB;
      Excel.Range rng;
      WB = xl.Workbooks.Open(Path);
      xl.Visible = true;
      int totalRows = 0;
      int totalCols = 0;
      foreach (Excel.Worksheet CurrentWS in WB.Worksheets) {
        rng = CurrentWS.UsedRange;
        totalCols = rng.Columns.Count;
        totalRows = rng.Rows.Count;
        for (int row = 1; row < totalRows; row++) {
          for (int col = 1; col < totalCols; col++) {
            textBox1.Text += rng.Rows[row].Cells[col].Value;
          }
          textBox1.Text += Environment.NewLine;
        }
      }
      WB.Close(false);
      xl.Quit();
      Marshal.ReleaseComObject(WB);
      Marshal.ReleaseComObject(xl);
    }
    // original posted code
    private void DoExcel() {
      textBox1.Text = "";
      string Path = @"D:\Test\Book1 - Copy.xls";
      Excel.Application xl = new Excel.Application();
      Excel.Workbook WB;
      Excel.Range rng;
 
      WB = xl.Workbooks.Open(Path);
      xl.Visible = true;
      foreach (Excel.Worksheet CurrentWS in WB.Worksheets) {
        rng = CurrentWS.UsedRange;
        for (int i = 1; i < rng.Count; i++) {
          textBox1.Text += rng.Cells[i].Value;
        }
      }
      WB.Close(false);
      xl.Quit();
      Marshal.ReleaseComObject(WB);
      Marshal.ReleaseComObject(xl);
    }

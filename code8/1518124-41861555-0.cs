    private void getData(int lastRow_) {
      double a, b, c, d, total = 0;
      //int lastRow_ = 4;
      foreach (DataGridViewRow r in dataGridView1.Rows) {
        //if (!row.IsNewRow) {
        if (!r.IsNewRow) {
            a = Convert.ToDouble(r.Cells[2].Value);
          b = Convert.ToDouble(r.Cells[3].Value);
          c = Convert.ToDouble(r.Cells[4].Value);
          d = Convert.ToDouble(r.Cells[5].Value);
          total = a + b + c + d;
          xlWorkSheet.Cells[lastRow_, 1] = "Hi";
          xlWorkSheet.Cells[lastRow_, 2] = "Hello";
          xlWorkSheet.Cells[lastRow_, 3] = Convert.ToString(total);
          lastRow_++;
          //lastRow_ = xlWorkSheet.Cells.Find(
          //            "*",
          //            xlWorkSheet.Cells[1, 1],
          //            misValue,
          //            Microsoft.Office.Interop.Excel.XlLookAt.xlPart,
          //            Microsoft.Office.Interop.Excel.XlSearchOrder.xlByRows,
          //            Microsoft.Office.Interop.Excel.XlSearchDirection.xlPrevious,
          //            misValue,
          //            misValue,
          //            misValue).Row + 1;
        }
      }
      total = 0;
    }

      private void button1_Click(object sender, EventArgs e)
      {
           string path = @"D:\Downloads\Windows\Prob.xls";
           Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
           Workbook wb = excel.Workbooks.Open(path);
           Worksheet excelSheet = wb.ActiveSheet;
           //Read a specific cell
           for (int i = 1; i <= 150; i++ )
           {
                Range cell = excelSheet.Cells[i + 1, 2] as Range;
                textBox1.AppendText(cell.Text + Environment.NewLine);
           }
           wb.Close();
      }

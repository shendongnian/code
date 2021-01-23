          private void button_Click(object sender, EventArgs e)
          {
               string path = @"C:\Test.xlsx";
               Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
               Workbook wb = excel.Workbooks.Open(path);
               Worksheet excelSheet = wb.ActiveSheet;
               //Read a specific cell
               Range cell = excelSheet.Cells[1, 3] as Range;
               // Show text content
               MessageBox.Show(cell.Text);
               wb.Close();
          }

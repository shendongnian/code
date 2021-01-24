    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using Syncfusion.XlsIO;
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable Table = new DataTable();
                Table.Columns.Add("Column1");
                Table.Columns.Add("Column2");
                Table.Columns.Add("Column3");
                Table.Rows.Add("Item1", "Item2", "Item3");
    
                ExcelEngine ExcelEngineObject = new Syncfusion.XlsIO.ExcelEngine();
                IApplication Application = ExcelEngineObject.Excel;
                Application.DefaultVersion = ExcelVersion.Excel2013;
                IWorkbook Workbook = Application.Workbooks.Create(1);
                IWorksheet Worksheet = Workbook.Worksheets[0];
                Worksheet.ImportDataTable(Table, true, 1, 1);
                Workbook.SaveAs("YourExcelFile.xlsx");
                Workbook.Close();
                ExcelEngineObject.Dispose();
    
            }
        }
    }

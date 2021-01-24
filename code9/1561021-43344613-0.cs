    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApplication10
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                // Create starting spreadsheet
    
                Microsoft.Office.Interop.Excel.Application excelApp;
                Microsoft.Office.Interop.Excel.Workbook excelWorkbook;
                Microsoft.Office.Interop.Excel.Worksheet excelWorksheet;
                Microsoft.Office.Interop.Excel.Range excelRange;
    
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                excelWorkbook = excelApp.Workbooks.Add();
                excelWorksheet = excelWorkbook.Sheets.Add();
    
                excelWorksheet.Activate();
    
                Microsoft.Office.Interop.Excel.Range range = excelWorksheet.Range[excelWorksheet.Cells[12, 2], excelWorksheet.Cells[5000, 2]];
    
                // Set some initial data
    
                int i = 1;
                foreach (Microsoft.Office.Interop.Excel.Range cell in range.Cells)
                {
                    cell.Value = i;
    
                    i++;
                }
    
                // Get the data from those cells
    
                object[,] cellValues = (object[,])range.Value;
                List<string> lst = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
    
                // Modify the strings in some way
    
                for (int m = 0; m < lst.Count; m++)
                {
                    lst[m] = lst[m] + "modified";
                }
    
                // Set the cells with the changes
    
                int z = 0;
                foreach (Microsoft.Office.Interop.Excel.Range cell in range.Cells)
                {
                    cell.Value = lst[z];
                    z++;
                }            
            }
        }
    }

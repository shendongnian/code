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
    
                excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                excelWorkbook = excelApp.Workbooks.Add();
                excelWorksheet = excelWorkbook.Sheets.Add();
    
                excelWorksheet.Activate();
    
                Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.Range[excelWorksheet.Cells[12, 2], excelWorksheet.Cells[5000, 2]];
    
                // Turn off updating to make it faster
    
                excelApp.ScreenUpdating = false;
    
                // Set some initial data
    
                int i = 1;
                foreach (Microsoft.Office.Interop.Excel.Range cell in excelRange.Cells)
                {
                    cell.Value = i;
    
                    i++;
                }
    
                // Get the data from those cells as a list of strings
    
                object[,] cellValues = (object[,])excelRange.Value;
                List<string> lst = cellValues.Cast<object>().ToList().ConvertAll(x => Convert.ToString(x));
    
                // Modify the strings in some way
    
                for (int l = 0; l < lst.Count; l++)
                {
                    lst[l] = lst[l] + "modified";
                }
    
                // Here are some different ways set the "cells" back
    
                // Set the cells back with the changes
                //------------------------------------
    
                // Option 1: using a multidimensional array
                
    /* 
                object[,] cellValuesToWrite = new string[excelRange.Rows.Count, excelRange.Columns.Count];
    
                int z = 0;
                foreach (string str in lst)
                {
                    cellValuesToWrite[z,0] = lst[z];
                    z++;
                }
    
                excelRange.Value2 = cellValuesToWrite;
    */
    
                // Option 2: iterating the range of cells and "setting" the value
    
    /*
                int z = 0;
                foreach (Microsoft.Office.Interop.Excel.Range cell in excelRange.Cells)
                {
                    cell.Value = lst[z];
                    z++;
                }
    
                excelRange.Value2 = lst;
    */
    
                // Turn updating back on
    
                excelApp.ScreenUpdating = true;
            }
        }
    }

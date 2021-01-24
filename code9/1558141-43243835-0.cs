    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    
    
    namespace WindowsFormsApplication5
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
                //"http://programmingeveryday.wordpress.com/2013/02/20/run-excel-macro-programmatically-in-c/"
                //~~> Define your Excel Objects
                Excel.Application xlApp = new Excel.Application();
    
                Excel.Workbook xlWorkBook;
    
                //~~> Start Excel and open the workbook.
                xlWorkBook = xlApp.Workbooks.Open("C:\\Users\\Ryan\\Desktop\\RunMacro.xlsb");
    
                //~~> Run the macros by supplying the necessary arguments
                xlApp.Run("ShowMessage");
    
                
                //~~> Clean-up: Close the workbook
                xlWorkBook.Close(false);
    
                //~~> Quit the Excel Application
                xlApp.Quit();
    
                //~~> Clean Up
                releaseObject(xlApp);
                releaseObject(xlWorkBook);
            }
    
            //~~> Release the objects
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
                }
                finally
                {
                    GC.Collect();
                }
            }
        }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    
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
                Excel.Application app = new Excel.Application();
    
                app.Visible = true;
                app.Workbooks.Add("");
                app.Workbooks.Add(@"C:\Users\Excel\Desktop\excel_files\Book1.xlsx");
                app.Workbooks.Add(@"C:\Users\Excel\Desktop\excel_files\Book2.xlsx");
    
    
                for (int i = 2; i <= app.Workbooks.Count; i++)
                {
                    int count = app.Workbooks[i].Worksheets.Count;
    
                    app.Workbooks[i].Activate();
                    for (int j = 1; j <= count; j++)
                    {
                        Excel._Worksheet ws = (Excel._Worksheet)app.Workbooks[i].Worksheets[j];
                        ws.Select(Type.Missing);
                        ws.Cells.Select();
    
                        Excel.Range sel = (Excel.Range)app.Selection;
                        sel.Copy(Type.Missing);
    
                        Excel._Worksheet sheet = (Excel._Worksheet)app.Workbooks[1].Worksheets.Add(
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing
                        );
    
                        sheet.Paste(Type.Missing, Type.Missing);
    
                    }
                }
            }
        }
    }

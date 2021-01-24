    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            Microsoft.Office.Interop.Excel.Application XL = null;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                XL = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
                foreach (Microsoft.Office.Interop.Excel.Workbook _wb in XL.Workbooks)
                {
                    this.listBox1.Items.Add(_wb.Name.ToString());
                }
            }
        }
    }

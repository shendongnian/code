    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApplication32
    {
        public partial class Form1 : Form
        {
            public Microsoft.Office.Interop.Excel.Application ExApp;
           
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ExApp = new Microsoft.Office.Interop.Excel.Application();
                // CREATE A NEW WORKBOOK (you can also open existing workbook using the Open() method)
                Microsoft.Office.Interop.Excel.Workbook Wb = ExApp.Workbooks.Add();
                // SET WORKSHEET
                Microsoft.Office.Interop.Excel.Worksheet Ws = Wb.Worksheets.Add();
                // MERGE CELLS (the answer to your question)
                Ws.Range["A1:G5"].Merge();
    
                ExApp.Visible = true;
            }
        }
    }

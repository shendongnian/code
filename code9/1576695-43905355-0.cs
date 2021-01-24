    using System;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var table = GenerateData();
                var maxNameLength = table.AsEnumerable().Max(row => ((string) row[1]).Length);
                var formatSpecifier = "{0,-5}{1,-" + (maxNameLength + 2) + "}{2,10}\r\n";
    
                foreach (DataRow row in table.Rows)
                {
                    richTextBox1.AppendText(string.Format(formatSpecifier, row[0], row[1], row[2]));
                }
            }
    
            private DataTable GenerateData()
            {
                DataTable table = new DataTable();
                for (int i = 0; i < 3; i++)
                {
                    table.Columns.Add("Column " + i.ToString(), typeof(string));
                }
    
                // Header
                DataRow dr = table.NewRow();
                dr[0] = "ID";
                dr[1] = "Item";
                dr[2] = "TotalPrice";
                table.Rows.Add(dr);
    
                // Data 0
                dr = table.NewRow();
                dr[0] = "1";
                dr[1] = "Monitor TV 10 cm";
                dr[2] = "100.50";
                table.Rows.Add(dr);
    
                // Data 1
                dr = table.NewRow();
                dr[0] = "1.1";
                dr[1] = @"HP DESKJET 3630 /3636 MULTIFUNKTIONS WIFI DRUCKER  ";
                dr[2] = "49.50";
                table.Rows.Add(dr);
                // Data 2
                dr = table.NewRow();
                dr[0] = "1.2";
                dr[1] = @"Canon PIXMA MG5750 Tintenstrahldrucker Multifunktionsgerät";
                dr[2] = "99.60";
                table.Rows.Add(dr);
    
                // Data 3
                dr = table.NewRow();
                dr[0] = "2";
                dr[1] = @"Dell UltraSharp U2715H 69 cm (27 Zoll) 16:9 ";
                dr[2] = "610.82";
                table.Rows.Add(dr);
    
                // Data 4
                dr = table.NewRow();
                dr[0] = "2";
                dr[1] = @"15.6' (39,62cm) HP 250 G5 I5/8GB/1TB/W10Home";
                dr[2] = "508.02";
                table.Rows.Add(dr);
    
                return table;
            }
        }
    }

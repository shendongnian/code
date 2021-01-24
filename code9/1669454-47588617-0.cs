    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                DataTable dt = new DataTable();
                dt.Columns.Add("Hesap Kodu*", typeof(string));
                dt.Columns.Add("Hesap Adı*", typeof(string));
                dt.Columns.Add("Evrak No", typeof(int));
                dt.Columns.Add("Evrak Tarihi", typeof(string));
                dt.Columns.Add("BT", typeof(string));
                dt.Columns.Add("Açıklama", typeof(string));
                dt.Columns.Add("Borç(TL)", typeof(string));
                dt.Columns.Add("Alacak(TL)", typeof(string));
                dt.Columns.Add("Miktar", typeof(string));
                dt.Rows.Add(new object[] { "A", "B", 1, "C", "D", "E", "F", "G", "H" });
                dataGridView1.DataSource = dt;
                dt.WriteXml("Filename");
            }
        }
    }

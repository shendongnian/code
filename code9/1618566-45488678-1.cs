     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using System.Windows.Forms;
        namespace sof
     {
         public partial class Form1 : Form
       {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Data.DataTable dTable = new DataTable();
            using (System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection("Data Source=.;Initial Catalog=testBase;Integrated security=true"))
            {
                using (System.Data.SqlClient.SqlDataAdapter sqlAdp = new System.Data.SqlClient.SqlDataAdapter("SELECT * FROM City WHERE City_Name LIKE 'Chalon%'", sqlConn))
                {
                    sqlConn.Open();
                    sqlAdp.Fill(dTable);
                }
            }
            dataGridView1.DataSource = dTable;
            //Create the ComboBoxColumn at the end of the grid
            var cmb = new DataGridViewComboBoxColumn();
            cmb.Name = "ComboCol";
            cmb.HeaderText = "ComboCol";
            cmb.DisplayMember = "Display";
            cmb.ValueMember = "Value";
            dataGridView1.Columns.Add(cmb);
            UpdateDataSourceCombo();
        }
        private void UpdateDataSourceCombo()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                var comboCell = (DataGridViewComboBoxCell)dataGridView1.Rows[i].Cells["ComboCol"];
                //Same datasource for every row just for testing
                if (i % 2 == 0)
                    comboCell.DataSource = new customObj[] { new sof.customObj("a", "a"), new sof.customObj("b", "b"), new customObj("c", "c") };
                else
                    comboCell.DataSource = new customObj[] { new sof.customObj("1", "1"), new sof.customObj("2", "2"), new customObj("3", "3") };
            }
        }
    }
    class customObj
    {
        public string Value { get; set; }
        public string Display { get; set; }
        public customObj(string value, string display)
        {
            this.Value = value;
            this.Display = display;
        }
    }
    }

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Globalization;
    using System.Data.SqlClient;
    using System.IO;
    using System.Configuration;
    namespace ADO_NET_Testbed
    {
        public partial class MainForm : Form
        {
            private SqlDataAdapter adapter;
            private string connectionString = @"Data Source=Server;Persist Security Info=True;Password=password!;User ID=sooperuser;Initial Catalog=Database";
            private string sqlcommand = @"SELECT OPID, LastName, FirstName, Title, PhoneOffice, PhoneCell, Email, Active, Admin, Tester, Educator, Developer FROM AuditUser";
            private SqlCommandBuilder cmdBuilder = new SqlCommandBuilder();
            private DataTable datatable = new DataTable();
            private DataSet dataset = new DataSet();
    
            public MainForm()
            {
                InitializeComponent();
            }
            private void MainForm_Load(object sender, EventArgs e)
            {
                adapter = new SqlDataAdapter(sqlcommand, connectionString);
                adapter.Fill(dataset, "AuditUser");
                dgvUsers.DataSource = dataset.Tables[0];
                dgvUsers.Enabled = true;
                this.Show();
            }
            private void btnCancel_Click(object sender, EventArgs e)
            {
                dataset.Clear();
                dataset.Reset();
                this.Close();
            }
            private void btnSave_Click(object sender, EventArgs e)
            {
                cmdBuilder.DataAdapter = adapter;
                adapter.Update(dataset.Tables[0]);
                this.Close();
            }
        }
    }

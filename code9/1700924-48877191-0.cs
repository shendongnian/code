    using System;
    using System.Data;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            SqlCommand sCommand;
            SqlDataAdapter sAdapter;
            SqlCommandBuilder sBuilder;
            DataSet sDs;
            DataTable sTable;        
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True";
                string sql = "SELECT * FROM Stores";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                sCommand = new SqlCommand(sql, connection);
                sAdapter = new SqlDataAdapter(sCommand);
                sBuilder = new SqlCommandBuilder(sAdapter);
                sDs = new DataSet();
                sAdapter.Fill(sDs, "Stores");
                sTable = sDs.Tables["Stores"];
                connection.Close();
                dataGridView1.DataSource = sDs.Tables["Stores"];
                dataGridView1.ReadOnly = true;
                save_btn.Enabled = false;
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
    
            private void new_btn_Click(object sender, EventArgs e)
            {
                dataGridView1.ReadOnly = false;
                save_btn.Enabled = true;
                new_btn.Enabled = false;
                delete_btn.Enabled = false;
            }
    
            private void delete_btn_Click(object sender, EventArgs e)
            {
                if (MessageBox.Show("Do you want to delete this row ?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    sAdapter.Update(sTable);
                }
            }
    
            private void save_btn_Click(object sender, EventArgs e)
            {
                sAdapter.Update(sTable);
                dataGridView1.ReadOnly = true;
                save_btn.Enabled = false;
                new_btn.Enabled = true;
                delete_btn.Enabled = true;
            }
        }
    }

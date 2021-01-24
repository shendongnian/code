    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace PointOfSale
    {
        public partial class Users : Form
        {
            MySqlCommand cmd;
            MySqlDataAdapter adapt;
            int ID = 0;
            private string conn;
            private MySqlConnection connect;
    
            public Users()
            {
                InitializeComponent();
                DisplayData();
            }
    
            private void db_connection()
            {
                try
                {
                    conn = "Server=localhost;Database=phvpos;Uid=root;Pwd=;";
                    connect = new MySqlConnection(conn);
                    connect.Open();
                }
                catch (MySqlException e)
                {
                    throw;
                }
            }
    
            //Insert Data  
            private void btnInsert_Click(object sender, EventArgs e)
            {
                
                if (txtName.Text != "" && txtPassword.Text != "" && txtUsertype.Text != "")
                {
                    db_connection();
    
                    cmd = new MySqlCommand("insert into accounts(username, password, usertype) values(@name,@password,@usertype)", connect);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@usertype", txtUsertype.Text);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    MessageBox.Show("Record Inserted Successfully");
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please Provide Details!");
                }
            }
            //Display Data in DataGridView  
            private void DisplayData()
            {
                db_connection();
                DataTable dt = new DataTable();
                adapt = new MySqlDataAdapter("select * from accounts", connect);
                adapt.Fill(dt);
                dataGridView1.DataSource = dt;
                connect.Close();
            }
            //Clear Data  
            private void ClearData()
            {
                txtName.Text = "";
                txtPassword.Text = "";
                ID = 0;
            }
            //dataGridView1 RowHeaderMouseClick Event  
            private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtUsertype.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            //Update Record  
            private void btnUpdate_Click(object sender, EventArgs e)
            {
                db_connection();
                if (txtName.Text != "" && txtPassword.Text != "" && txtUsertype.Text != "")
                {
                    cmd = new MySqlCommand("update accounts set username=@name,password=@password,usertype=@usertype where userid=@userid", connect);
                    cmd.Parameters.AddWithValue("@userid", ID);
                    cmd.Parameters.AddWithValue("@name", txtName.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@usertype", txtUsertype.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    connect.Close();
                    DisplayData();
                    ClearData();
                }
                else
                {
                    MessageBox.Show("Please Select Record to Update");

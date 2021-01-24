    namespace FairyTailHRSolution
    {
        public partial class Form1 : Form
        {
            //Get rid of member variable for the connection. Add constant for connection string.
            private const string ConnectionString = @"Data Source = LAPTOP-VHSGV41H\SQLEXPRESS; Initial Catalog = EmpDB; Integrated Security = True";  
            
            private void button1_Click(object sender, EventArgs e)
            {
                //Use using and use a local variable for the connection
                using (var con=new SqlConnection(this.ConnectionString))
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO FRYEMP (EmployeeID, EmployeeName, EmployeePosition, EmployeeSalary) VALUES (@EmployeeID, @EmployeeName, @EmployeePosition, @EmployeeSalary)", con);
                    cmd.Parameters.Add("@EmployeeID", textBox1.Text);
                    cmd.Parameters.Add("@EmployeeName", textBox2.Text);
                    cmd.Parameters.Add("@EmployeePosition", textBox3.Text);
                    cmd.Parameters.Add("@EmployeeSalary", textBox4.Text); 
                    cmd.ExecuteNonQuery();
                }
            }
    
    
            private void textBox5_TextChanged(object sender, EventArgs e)
            {
                if(comboBox1.Text == "EmployeeID")
                {
                    //Create a new connection each time you need one
                    using (var con = new SqlConnection(this.ConnectionString))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, EmployeeName,EmployeePosition, EmployeeSalary FROM FRYEMP where EmployeeID like @employeeID", con);
                        da.SelectCommand.Parameters.AddWithValue("@employeeID", "%" + textBox5.Text + "%");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
                else if (comboBox1.Text == "EmployeeName")
                {
                    using (var con = new SqlConnection(this.ConnectionString))
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, EmployeeName,EmployeePosition, EmployeeSalary FROM FRYEMP where EmployeeName like @employeeName", con);
                        da.SelectCommand.Parameters.AddWithValue("@employeeName", "%" + textBox5.Text + "%");
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }

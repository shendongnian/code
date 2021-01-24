    namespace FairyTailHRSolution
    {
        public partial class Form1 : Form
        {
            SqlCommand cmd;
            SqlConnection con;
            SqlDataAdapter da;
            public Form1()
            {
                InitializeComponent();
                con=new SqlConnection(@"Data Source = LAPTOP-VHSGV41H\SQLEXPRESS; Initial Catalog = EmpDB; Integrated Security = True");
                con.Open();
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
            }
            private void button1_Click(object sender, EventArgs e)
            {
                cmd = new SqlCommand("INSERT INTO FRYEMP (EmployeeID, EmployeeName, EmployeePosition, EmployeeSalary) VALUES (@EmployeeID, @EmployeeName, @EmployeePosition, @EmployeeSalary)", con);
                cmd.Parameters.Add("@EmployeeID", textBox1.Text);
                cmd.Parameters.Add("@EmployeeName", textBox2.Text);
                cmd.Parameters.Add("@EmployeePosition", textBox3.Text);
                cmd.Parameters.Add("@EmployeeSalary", textBox4.Text); 
                cmd.ExecuteNonQuery();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
            }
            private void textBox2_TextChanged(object sender, EventArgs e)
            {
            }
            private void label1_Click(object sender, EventArgs e)
            {
            }
            private void label2_Click(object sender, EventArgs e)
            {
            }
            private void find_Click(object sender, EventArgs e)
            {
            }
            private void textBox5_TextChanged(object sender, EventArgs e)
            {
                if(comboBox1.Text == "EmployeeID")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, EmployeeName,EmployeePosition, EmployeeSalary FROM FRYEMP where EmployeeID like @employeeID", con);
                    da.SelectCommand.Parameters.AddWithValue("@employeeID", "%" + textBox5.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                else if (comboBox1.Text == "EmployeeName")
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, EmployeeName,EmployeePosition, EmployeeSalary FROM FRYEMP where EmployeeName like @employeeName", con);
                    da.SelectCommand.Parameters.AddWithValue("@employeeName", "%" + textBox5.Text + "%");
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
            }
        }
       }

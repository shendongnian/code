    using System.Data.SqlClient;
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con;
            con = new SqlConnection(@"Data Source=" + textBox1.Text + ";Initial Catalog=DBName;user ID=sa;Password=yourpassword");
            con.Open();
        }

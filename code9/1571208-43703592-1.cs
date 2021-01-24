    private void btn_search_Click(object sender, EventArgs e) {
       String bResult = boxSearch.Text;
       string connectionString = "Data Source=.;Initial Catalog=sacbase;Integrated Security=True"; // add your conncetion string here
       SqlConnection connection = new SqlConnection(connectionString);
       SqlCommand cmd = new SqlCommand("SELECT * FROM Student where No_ic =@val", connection);
       cmd.Parameters.AddWithValue("@val", bResult);
       SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
       DataSet ds = new DataSet();
       connection.Open();
       dataadapter.Fill(ds, "student_table");
       connection.Close();
       dataGridView1.DataSource = ds;
       dataGridView1.DataMember = "student_table";
    }

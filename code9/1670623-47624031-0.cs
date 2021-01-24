    private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DC-POR\\SQLEXPRESS;Initial Catalog=por_test;Integrated Security=True;";
            SqlConnection con = new SqlConnection(connectionString);
             
            con.Open();
            string sql = "INSERT into tbl_persons (person_id,p_name,p_surname) VALUES (55,'TEST','test')";
            SqlCommand cmd = new SqlCommand(sql);
            cmd.ExecuteNonQuery();
            con.Close();
        }

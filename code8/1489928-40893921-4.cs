      public void button2_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
            string nazwa = dataGridView1.SelectedRows[row.Index].ToString();
           //Check if checkbox is checked.
            if(Convert.ToBoolean(row.Cells[0].Value))
           {
                string con = ConfigurationManager.ConnectionStrings["someConString"].ConnectionString;
                    SqlConnection connection = new SqlConnection(con);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Delete From Klienci where Nazwa=@Nazwa", connection);
                    cmd.Parameters.AddWithValue("@Nazwa", nazwa);
                    cmd.ExecuteNonQuery();
                    connection.Close();
            }
     }

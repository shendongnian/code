      public void button2_Click(object sender, EventArgs e)
    {
     for  (int i=DataGridView1.Rows.Count-1; i>=0; i--)
            {
     //Find the checkbox from the DataGridView
     CheckBox chk = dataGridView1.Rows[i].FindControl("checkbox1") as CheckBox;
     string nazwa = dataGridView1.SelectedRows[i].Index.ToString();
        if(chk.Checked)
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

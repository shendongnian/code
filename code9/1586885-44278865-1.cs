    private void button3_Click(object sender, EventArgs e)
         {
             string connStr = "Data Source=localhost;port=3306;Initial Catalog=bitdb;User Id=root;Password='';"; 
             string query = "Select * from Client"; 
             using (MySqlConnection conn = new MySqlConnection(connStr))
             {
                 using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                 {
                     DataSet ds = new DataSet();
                     adapter.Fill(ds);
                     var bindingSource = new BindingSource();
                     bindingSource.DataSource = ds.Tables[0];
                     dataGridView1.DataSource = bindingSource;
                 }
             }
         }

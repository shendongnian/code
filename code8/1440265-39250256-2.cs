    private void searchTextBoxNaziv_TextChanged(object sender, EventArgs e)
        {
            String selectedColumn = filterSearchCombo.Text;
            String sql = "";
            conn = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            com = new MySqlCommand("select * from grupe_artikala where lcase(@searchItem) like %@search%", conn);
            if (searchTextBoxNaziv.Text.length > 0)
            {
                com.Parameters.AddWithValue("@search", searchTextBoxNaziv.Text.ToLower());
                switch (selectedColumn)
                {
                    case "ID":
                        com.Parameters.AddWithValue("@searchItem", "ID");
                        break;
                    case "Name":
                        com.Parameters.AddWithValue("@searchItem", "Name");
                        break;
                    case "Descr":
                        com.Parameters.AddWithValue("@searchItem", "Desc");
                        break;
                    case "Created":
                        com.Parameters.AddWithValue("@searchItem", whateverCreatedIs);
                        break;
                }
                GetData(conn, com);
            }
        }
        private void GetData(MySqlConnection conn, MySqlCommand com)
        {
            try
            {
                conn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = com;
                dt = new DataTable();
                bs = new BindingSource();
                da.Fill(dt);
                bs = new BindingSource();
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;
                conn.Close();
                conn.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

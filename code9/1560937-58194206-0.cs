            try
            {
                listView1.Items.Clear();
          MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;port=3306;uid=sql3305088;pwd=KwxUiLHnKt;database=sql3305088;");
                con.Open();
                MySqlCommand com = con.CreateCommand();
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "SELECT * From eslamtarek";
                MySql.Data.MySqlClient.MySqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ListViewItem lv = new ListViewItem();
                        lv.Text = reader.GetString(0);
                        lv.SubItems.Add(reader.GetString(1));
                        lv.SubItems.Add(reader.GetString(2));
                        lv.SubItems.Add(reader.GetString(3));
                        lv.SubItems.Add(reader.GetString(4));
                        listView1.Items.Add(lv);
                    }
                   
                    reader.Close();
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

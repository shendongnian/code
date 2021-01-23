        String path = "Data Source = LOCALHOST; Initial Catalog= sample_database; username='root'; password=''";
            MySqlConnection sqlcon = new MySqlConnection(path);
            MySqlCommand sqlcom = new MySqlCommand();
            MySqlDataReader sqlread;
            sqlcon.Open();
            sqlcom.CommandType = CommandType.Text;
            sqlcom.CommandText = "SELECT name from database_table where city = '"+TextBox1.text+"'";
            sqlcom.Connection = sqlcon;
            sqlread = sqlcom.ExecuteReader();
            while (sqlread.Read())
            comboBox1.Items.Add(sqlread[0].ToString());
            sqlcon.Close();

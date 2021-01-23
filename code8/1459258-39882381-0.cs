      SqlCommand sqlCmd = new SqlCommand("SELECT name FROM Inventorymaster", con);
            con.Open();
            SqlDataReader sqlReader = sqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                Column1.Items.Add(sqlReader["name"].ToString());
            }
            sqlReader.Close();

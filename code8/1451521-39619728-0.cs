    void showdata() {
        //declare parameters
        SqlParameter paraType = new SqlParameter("@Type", SqlDbType.VarChar);
        SqlParameter paraMusic = new SqlParameter("@Music", SqlDbType.VarChar);
        SqlParameter paraPlace = new SqlParameter("@Place", SqlDbType.VarChar);
        SqlParameter paraDrink = new SqlParameter("@Drink", SqlDbType.VarChar);
        //append the parameters
        if (string.IsNullOrEmpty(comboBox1.Text)) {
            paraType.Value = DBNull.Value;
        } else {
            paraType.Value = comboBox1.Text;
        }
        if (string.IsNullOrEmpty(comboBox2.Text)) {
            paraMusic.Value = DBNull.Value;
        } else {
            paraMusic.Value = comboBox2.Text;
        }
        if (string.IsNullOrEmpty(comboBox3.Text)) {
            paraPlace.Value = DBNull.Value;
        } else {
            paraPlace.Value = comboBox3.Text;
        }
        if (string.IsNullOrEmpty(comboBox4.Text)) {
            paraDrink.Value = DBNull.Value;
        } else {
            paraDrink.Value = comboBox4.Text;
        }
        //construct the query
        SqlCommand com = new SqlCommand();
        com.Connection = con;
        com.CommandType = CommandType.Text;
        com.CommandText = "SELECT * FROM Magazia WHERE Type = @Type AND Music = @Music AND Place = @Place AND Drink = @Drink";
        com.Parameters.Add(paraType);
        com.Parameters.Add(paraMusic);
        com.Parameters.Add(paraPlace);
        com.Parameters.Add(paraDrink);
        //get the data and put it into the datagrid
        dataGridView1.DataSource = com.ExecuteReader();
        //tidy up
        com.Dispose();
        con.Close();
        con.Dispose();
    }

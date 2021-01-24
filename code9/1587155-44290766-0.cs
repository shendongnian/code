    if (!carmodel.Items.Any())
    {
        MySqlConnection sqlConn = new MySqlConnection(myConnectionString);
        MySqlCommand cmdDatabase = new MySqlCommand(SelectQuery, sqlConn);
        MySqlDataReader myReader;
        try
        {
        sqlConn.Open();
        myReader = cmdDatabase.ExecuteReader();
        // int model = myReader.GetOrdinal("model");
        //int model1 = myReader.GetOrdinal("part");
        while (myReader.Read())
        {
        //  string namethestore = myReader.IsDBNull(model)
        //   ? string.Empty
        //  : myReader.GetString("model");
        //   this.carmodel.Text = namethestore;
        //  string namethestore1 = myReader.IsDBNull(model)
        //  ? string.Empty
        // : myReader.GetString("parts");
        ///  this.carpart.Text = namethestore1;
        carmodel.Items.Add(myReader["Model"].ToString());
        carpart.Items.Add(myReader["Part"].ToString());
        }
        }
        catch (Exception msg)
        {
        MessageBox.Show(msg.Message);
        }
    }

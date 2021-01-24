    try
    {
        // POPULATE MODELS
        string modelsQuery = "SELECT Model FROM ctautoparts.nissan;";
        using (MySqlConnection sqlConn = new MySqlConnection(myConnectionString))
        {
            using (MySqlCommand cmdDatabase = new MySqlCommand(modelsQuery, sqlConn))
            {
                sqlConn.Open();
                MySqlDataReader myReader = cmdDatabase.ExecuteReader();
                // int model = myReader.GetOrdinal("model");
                //int model1 = myReader.GetOrdinal("part");
                while (myReader.Read())
                {
                    carmodel.Items.Add(myReader["Model"].ToString());
                }
            }
        }
        // POPULATE PARTS
        string partsQuery = "SELECT Part FROM ctautoparts.nissanpart;";
        using (MySqlConnection sqlConn = new MySqlConnection(myConnectionString))
        {
            using (MySqlCommand cmdDatabase = new MySqlCommand(partsQuery, sqlConn))
            {
                sqlConn.Open();
                MySqlDataReader myReader = cmdDatabase.ExecuteReader();
                // int model = myReader.GetOrdinal("model");
                //int model1 = myReader.GetOrdinal("part");
                while (myReader.Read())
                {
                    carpart.Items.Add(myReader["Part"].ToString());
                }
            }
        }
    }
    catch (Exception msg)
    {
        MessageBox.Show(msg.Message);
    }

    try
    {
        // POPULATE MODELS
        string modelsQuery = "SELECT Model FROM ctautoparts.nissan;";
        using (SqlConnection sqlConn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmdDatabase = new SqlCommand(modelsQuery, sqlConn))
            {
                sqlConn.Open();
                SqlDataReader myReader = cmdDatabase.ExecuteReader();
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
        using (SqlConnection sqlConn = new SqlConnection(myConnectionString))
        {
            using (SqlCommand cmdDatabase = new SqlCommand(partsQuery, sqlConn))
            {
                sqlConn.Open();
                SqlDataReader myReader = cmdDatabase.ExecuteReader();
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

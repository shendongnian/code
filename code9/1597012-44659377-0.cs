    public void getCarToUpdate(int? id)
    {
        try
        {
            if (dbConn.State != ConnectionState.Open)
            {
                dbConn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT ID, carMake, carModel, engine, deleteStatus FROM myprojectdb WHERE ID = ?ID";
                cmd.Parameters.Add("?ID", MySqlDbType.Int16).Value = id;
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ID = (int)reader[0];
                        carMake = (string)reader[1];
                        carModel = (string)reader[2];
                        Engine = (string)reader[3];
                        deleteStatus = (string)reader[4];
                    }
                }
                reader.Close();
                dbConn.Close();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        dbConn.Close();
    }

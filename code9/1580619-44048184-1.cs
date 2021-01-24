    public List<company> getSots()
        {
            string query = "SELECT * FROM tbl_spot"; //Your table name here
            List<Spot> dbSpots = new List<Spot>(); //List to store the gathered spots
            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    //Create a new company object and populate with a row at a time
                    Spot x = new Spot();
                    x.Id = int.Parse(dataReader["id_spot"].ToString());
                    x.Number = int.Parse(dataReader["number"].ToString());
                    x.Capacity = int.Parse(dataReader["capacity"].ToString());
                    dbSpots.Add(x); //Add created Spot to the Spots list
                }
                dataReader.Close();
                this.CloseConnection();
                return dbCmpys; //Return the gathered db companies
            }
            else { return dbCmpys; }
        }

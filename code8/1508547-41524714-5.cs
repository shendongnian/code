    // create a user object from an ID
    public static User Load(int id)
    {
        string sql = "SELECT * FROM gebruiker WHERE Id = @id";
        using (var dbCon = new MySqlConnection(dbConnStr))
        using (var cmd = new MySqlCommand(sql, dbCon))
        {
            dbCon.Open();
            cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            using (var rdr = cmd.ExecuteReader())
            {
                if (rdr.HasRows)
                {
                    User U = new User();
                    rdr.Read();
                    U.Id = id;
                    U.Name = rdr.GetString(rdr.GetOrdinal("FirstName"));
                    U.LastName = rdr.GetString(rdr.GetOrdinal("LastName"));
                    U.DateOfBirth = rdr.GetDateTime(rdr.GetOrdinal("BirthDate"));
                    //...
                    return U;
                }
                else { return null; }
            }
        }
    }

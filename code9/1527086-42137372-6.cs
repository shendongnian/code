    public Task<string> GetGender(string user)
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            await con.OpenAsync();
            genderCmd.Connection=con;
            genderCmd.Parameters["@user"].Value=user;
            var gender=await genderCmd.ExecuteScalarAsync();
            return (string)gender;
        }
    }

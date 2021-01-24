    using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myCNN"].ConnectionString))
    {
        using (var cmd = new SqlCommand("dbo.myStoredProcedure", connection))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PatientId", SqlDbType.VarChar, 40).Value = number;
            cmd.Parameters.Add("@NickName", SqlDbType.VarChar, 20).Value = "stlukeshs";                            
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                //Do Stuff..
            }
            //closer reader
            reader.Close();
        }
    }

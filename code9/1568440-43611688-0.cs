    using(var sqlConnection1 = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=MyDB;Trusted_Connection=True;MultipleActiveResultSets=true")
    { 
        using(var cmd = new SqlCommand()
        {
            CommandText = "SELECT * FROM dbo.Candidates WHERE id = @id",
            CommandType = CommandType.Text,
            Connection = sqlConnection1
        })
        {
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = model.CandidateId
            sqlConnection1.Open();
            using(var reader = cmd.ExecuteReader())
            {
                if(reader.Read())
                {
                    var id = reader[0];
                    var whatEver = reader[1];
                    // get the rest of the columns you need the same way
                }
            }
        }
    }

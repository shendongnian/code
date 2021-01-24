    string command= "select * from SI where Course = @course";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand cmd = new SqlCommand(command, connection))
        {
            cmd.Parameters.Add("@course", SqlDbType.VarChar).Value = course;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {                        
                if (read.Read())
                {
                    siname = read["Name"].ToString();
                    siemail = read["Email"].ToString();
                }
            }
        }
    }

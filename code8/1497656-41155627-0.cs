    string querySql = "Select Name,Father_name,NIC_No,Image from Admform WHERE Member_ID=@memid";.
    using (SqlConnection conSql = new SqlConnection("ConnectionString"))
    {
        using (SqlCommand command = new SqlCommand(querySql , conSql ))
        {
            conSql.Open();
            command.Parameters.AddWithValue("@memid", textBoxmember.Text);
            SqlDataReader reader= command.ExecuteReader();
            while(reader.Read())
            {
                  // Access your values here
            }  
        }
    }

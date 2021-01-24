    public contact displayContact(int? Id)
    {
        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            using (SqlCommand comObj = new SqlCommand("displayContact", conn))
            {
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Parameters.Add(new SqlParameter("@contactId", Id));
                conn.Open();
                using (SqlDataReader dr = comObj.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        return new contact
                        {
                            contactId = int.Parse(dr["contactId"].ToString()),
                            establishmentType = dr["establishmentType"].ToString(),
                            ownerName = dr["ownerName"].ToString(),
                            address = dr["address"].ToString(),
                            city = dr["city"].ToString(),
                            region = dr["region"].ToString(),
                            mobileNumber = dr["mobileNumber"].ToString(),
                            phoneNumber = dr["phoneNumber"].ToString()
                        };
                    }
                }
            }
    
            conn.Close();
        }
        return null;
    }

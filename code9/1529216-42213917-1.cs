    public string moduleName(string id)
    {
        string returnValue = "<ul>";
        using (SqlConnection con = new SqlConnection(DB))
        {
            using (SqlCommand com = new SqlCommand("SELECT * FROM module WHERE id = @id", con))
            {
                com.Parameters.AddWithValue("@id", id);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                    using (SqlDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {                            
                            returnValue += "<li>"+ dr["modulename"].ToString()+"</li>";
                        }
                    }
                    con.Close();
                }
            }
        }
        returnValue += "</ul>";
        return returnValue;
    }

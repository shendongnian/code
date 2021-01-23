     public Project GetData()
        {
    
            using (SqlConnection con = new SqlConnection(this.Connection))
            {
                con.Open();
                SqlCommand command = new SqlCommand("Select TITTLE,VALUE from T_PROJECTS ", con);
                Project proObj = new Project();            
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    proObj.Title = reader["TITTLE"].ToString();
                    proObj.Value = reader["VALUE"].ToString();
                }
    
            }
         return proObj;
        }

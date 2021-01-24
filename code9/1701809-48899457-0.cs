    private DropDownList PopulateDropDown()
            {
                DropDownList lst = new DropDownList();
                try
                {
                    DC.dbConnection = Database.getInstance();
                    DC.dbConnection.Open();
    
                    DC.dbCommand = new SqlCommand("SP_Employee", DC.dbConnection);
                    DC.dbCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    DC.dbCommand.Parameters.AddWithValue("@Action", "SelectEmployeeList");
    
                    DC.dbReader = DC.dbCommand.ExecuteReader();
    
                    while(DC.dbReader.Read())
                    {
                        lst.Items.Add(DC.dbReader["Name"].ToString());
                    }
                    
                    DC.dbConnection.Close();
    
                }catch(Exception ex)
                {
    
                }
                return lst;
            }

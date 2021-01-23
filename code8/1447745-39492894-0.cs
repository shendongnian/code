    protected void SaveButton_Click(object sender, EventArgs e)
    {
        string StrQuery;
    
        try
        {
    	    // define connection string and INSERT query WITH PARAMETERS
            string connectionString = @"Data Source = C:\EmployeeWebProject\EmployeeWebProject\App_Data\EmployeeDatabase.sdf";
            string insertQry = "INSERT INTO Employees(Col1, Col2, Col3, Col4, Col5) " + 
                               "VALUES(@Col1, @Col2, @Col3, @Col4, @Col5);";
    		
    		// define connection and command for SQL Server CE
            using (SqlCeConnection conn = new SqlCeConnection(connectionString))
            using (SqlCeCommand cmd = new SqlCeCommand(insertQry, conn))
            {
    		    // add parameters to your command - adapt those *as needed* - we don't know your table structure,
    			// nor what datatype (and possibly length) those parameters are !
                cmd.Parameters.Add("@Col1", SqlDbType.Int);
    			cmd.Parameters.Add("@Col2", SqlDbType.VarChar, 100);
    			cmd.Parameters.Add("@Col3", SqlDbType.VarChar, 100);
    			cmd.Parameters.Add("@Col4", SqlDbType.VarChar, 100);
    			cmd.Parameters.Add("@Col5", SqlDbType.VarChar, 100);
    
    		    conn.Open();
    
                for (int i = 0; i < GridView1.Rows.Count; i++)
                {
                    // set parameter values
                    cmd.Parameters["@Col1"].Value = Convert.ToInt32(GridView1.Rows[i].Cells[0]);
    			    cmd.Parameters["@Col2"].Value = GridView1.Rows[i].Cells[1].ToString();
    			    cmd.Parameters["@Col3"].Value = GridView1.Rows[i].Cells[1].ToString();
    			    cmd.Parameters["@Col4"].Value = GridView1.Rows[i].Cells[1].ToString();
    			    cmd.Parameters["@Col5"].Value = GridView1.Rows[i].Cells[1].ToString();
    
                    cmd.ExecuteNonQuery();
                }
            }
        }
        finally
        {
        }
    }

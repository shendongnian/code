    public static int InsertWithParam(string table, string column1, string column2, string value1, string value2)
    {
        -----------------------------------------------------------------------
        -- Substitute in the table and column names, hard code parameter names
        -- Ensure adequate white space between names, etc
        -----------------------------------------------------------------------
        string.Format("INSERT INTO {0} ({1}, {2}) VALUES (@value1, @value2)", table, column1, column2);
    
        try
        {
            using (OleDbConnection connect = new OleDbConnection(connectinstring)) 
            {
                using (var command = new OleDbCommand(str, connect))
                {
                    --------------------------------------------------------------------
                    -- Reference the hard coded parameter names during parameterisation
                    --------------------------------------------------------------------
                    command.Parameters.Add(new OleDbParameter("@value1", value1));
                    command.Parameters.Add(new OleDbParameter("@value2", value2));
    
                    connect.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception e) 
        {
             Console.WriteLine(e.Message); 
        }
        return 0;
    }

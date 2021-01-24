    public static void UpdateDB(string valToUpdate)
    {
        SQLConnection conn = GetConnection();
        using (conn)
        {
        SQLCommand updateCommand = new SQLCommand(GetConnection(), "Update Table 
        Set Val = @newValue");
        updateCommand.Parameters.AddWithValue("@newValue", valToUpdate);
        conn.Open();
        updateCommand.ExecuteNonQuery();
        }
    }

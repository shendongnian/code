    string ReturnValue;
    SQLiteConnection DBConnection;
    DBConnection = GetMyconnection();
    DBConnection.Open();
    string DBCommand = "SELECT setting_value FROM settings WHERE setting_key = @settingkey LIMIT 1";
    using (SQLiteCommand sqlCommand = new SQLiteCommand(DBCommand, DBConnection)) {
        sqlCommand.parameters.AddWithValue("@settingkey", setting_key);
        try {
            object data = sqlCommand.ExecuteScalar();
            ReturnValue = (data != null) ? data.ToString() : "Error";
        }
        catch (Exception ex) { ReturnValue = "Exception: " + ex.Message; }
    }
    DBConnection.Close();
    return ReturnValue;

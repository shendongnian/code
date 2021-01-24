    private string UpdateRate(DateTime dateFrom, string newRate, string oldRate)
    {
        string connectionString = "datasource=;port=;username=;password=";
        var connection = new MySqlConnection(connectionString);
        try
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("UpdateRate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@p_DateFrom", MySqlDbType.Date).Value = dateFrom;
            cmd.Parameters.Add("@p_NewAmount", MySqlDbType.Decimal).Value = newRate;
            cmd.Parameters.Add("@p_OldAmount", MySqlDbType.Decimal).Value = oldRate;
            cmd.ExecuteNonQuery();
            return newRate;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return null;
    }

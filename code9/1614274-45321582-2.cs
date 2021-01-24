    SqlCommand cmd = new SqlCommand("Select finaldays from LeaveTest where Id  = @id", con);
    cmd.Parameters.Add("@id", SqlDbType.VarChar);
    cmd.Parameters["@id"].Value = comboBox1.SelectedText;
    try
    {
        List<int> resultList = new List<int>();
        conn.Open();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            resultList.Add((Int32)reader[0]);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

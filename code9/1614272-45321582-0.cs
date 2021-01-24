    SqlCommand cmd = new SqlCommand("Select finaldays from LeaveTest where Id  = @id", con);
    cmd.Parameters.Add("@id", SqlDbType.VarChar);
    cmd.Parameters["@id"].Value = comboBox1.SelectedText;
    try
    {
        conn.Open();
        int result = (Int32)cmd.ExecuteScalar();
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

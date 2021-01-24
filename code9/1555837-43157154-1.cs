    connection.Open();
    SqlCommand command = new SqlCommand("UPDATE table SET column1 = column1 + @column1 WHERE column2 = @column2", connection);
    SqlDataAdapter adp = new SqlDataAdapter();
    adp.UpdateCommand = command;
    adp.UpdateCommand.Parameters.Add(new SqlParameter("@column1", SqlDbType.Int));
    adp.UpdateCommand.Parameters.Add(new SqlParameter("@column2", SqlDbType.VarChar));
    adp.UpdateCommand.Parameters["@column1"].Value = Convert.ToInt32(TextBox.Text);
    adp.UpdateCommand.Parameters["@column2"].Value = ComboBox.Text;
    try
    {
        adp.UpdateCommand.ExecuteNonQuery();
    }
    catch (SqlException ex)
    {
        MessageBox.Show(ex.ToString());
    }
    finally
    {
        connection.Close();
    }

    SqlConnection _connection;
    SqlCommand _command;
    _connection = new SqlConnection(@"Data Source=someserver;Initial Catalog=sometable;Integrated Security=True");
    _connection.Open();
    _command = _connection.CreateCommand();
    _command.CommandType = CommandType.StoredProcedure;
    private void SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            _command.CommandText = "someprocedurename";
            _command.Parameters.Add("@someparameter", SqlDbType.NVarChar).Value = combobox1.SelectedValue.ToString();
            _command.ExecuteNonQuery();
    }
    catch (Exception)
    {
        MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
     finally
     {
        _connection.Close();
      }
    }

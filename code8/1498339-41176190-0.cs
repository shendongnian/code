    string sql = "SELECT * FROM SOMETABLE WHERE someColumn = @comboboxparam";
    
    using (SqlConnection connection = new SqlConnection())
    using (SqlCommand command = new SqlCommand(sql, connection))
    {
        var comboBoxParam = new SqlParameter("someColumn", SqlDbType.Text);
        comboBoxParam.Value = comboBox.Text;
    
        command.Parameters.Add(comboBoxParam);
        var results = command.ExecuteReader();
    }

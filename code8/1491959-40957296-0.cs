    using(SqlConnection(System.Configuration.ConfigurationManager
                              .ConnectionStrings["ConnectionString"].ToString())){
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        string sql = "INSERT INTO RegisterUser(Name,LastName,email,Nationality,Country) VALUES (@param1,@param2,@param3,@param4,@param5)";
        SqlCommand cmd = new SqlCommand(sql, con);
        cmd.Parameters.Add("@param1", SqlDbType.NVarChar, 200).Value = txtName.Text;
        cmd.Parameters.Add("@param2", SqlDbType.NVarChar, 100).Value = txtLastName.Text;
        cmd.Parameters.Add("@param3", SqlDbType.NVarChar, 50).Value = txtEmail.Text;
        cmd.Parameters.Add("@param4", SqlDbType.NVarChar, 50).Value = ddCountry.SelectedItem.Value.ToString();
        cmd.Parameters.Add("@param5", SqlDbType.NVarChar, 50).Value = txtCountryCode.Text;
        cmd.CommandType = CommandType.Text;
        cmd.ExecuteNonQuery();
    }

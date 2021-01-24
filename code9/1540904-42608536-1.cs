    DataTable dt;
    using(var sqlCon = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["carConnectionString"]))
    {
        sqlCon.Open();
        using(var scCommand = new SqlCommand("Carstored", sqlCon))
        {
            scCommand.CommandType = CommandType.StoredProcedure;
            scCommand.Parameters.Add("@Ta", SqlDbType.Int).Value = DropDownList1.SelectedValue;
            scCommand.Parameters.Add("@Em", SqlDbType.Int).Value = DropDownList2.SelectedValue;
            scCommand.Parameters.Add("@Ma", SqlDbType.Int).Value = DropDownList3.SelectedValue;
            scCommand.Parameters.Add("@Sa", SqlDbType.Int).Value = DropDownList4.SelectedValue;
            using (SqlDataAdapter sda = new SqlDataAdapter(scCommand))
            {
                dt = new DataTable();
                sda.Fill(dt);
            }
        }
    }

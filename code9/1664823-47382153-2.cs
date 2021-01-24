    using (var  myConnection = new SqlConnection(connectionstring))
    using (var  myCommand = new SqlCommand(myCommandString, myConnection))
    using (var  myydata = new SqlDataAdapter())
    {
        myCommand.Parameters.Add(new SqlParameter("@Collection1", comboBox1.Text));
        myydata.SelectCommand = myCommand;
        myConnection.Open();
        DataTable myytab = new DataTable();
        myydata.Fill(myytab);
    }

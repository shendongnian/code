    string myCommandString = "SELECT Name, Collection, Text FROM List_Card";
    using (var  myConnection = new SqlConnection(connectionstring))
    using (var  myCommand = new SqlCommand(myCommandString, myConnection))
    using (var  myydata = new SqlDataAdapter())
    {
        if (comboBox1.Text != "")
        {
            myCommandString += " WHERE Collection IN (SELECT Shortcut FROM Collections WHERE Collection Like @Collection1)";
            myCommand.Parameters.Add(new SqlParameter("@Collection1", comboBox1.Text));
        }
        myydata.SelectCommand = myCommand;
        myConnection.Open();
        DataTable myytab = new DataTable();
        myydata.Fill(myytab);
    }

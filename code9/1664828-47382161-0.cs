    string myCommandString = @"select Name, Collection, Text from 
    List_Card where Collection IN 
    	(select Shortcut from Collections where Collection Like '%' + @collection + '%')";
    SqlConnection myConnection = new SqlConnection(connectionstring);
    SqlCommand myCommand = new SqlCommand(myCommandString, myConnection);
    SqlDataAdapter myydata = new SqlDataAdapter();
    myCommand.Parameters.Add(new SqlParameter("@Collection1", comboBox1.Text));
    myydata.SelectCommand = myCommand;
    myConnection.Open();
    DataTable myytab = new DataTable();
    myydata.Fill(myytab);

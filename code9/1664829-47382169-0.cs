    var myCommandString = "select Name, Collection, Text from List_Card ";
    if (comboBox1.Text != "")
    {
        myCommandString += " where Collection IN (select Shortcut from Collections where Collection Like '@Collection1')";
    }
    using (var myConnection = new SqlConnection(connectionstring))
    using (var myCommand = new SqlCommand(myCommandString, myConnection))
    {
        myCommand.Parameters.Add(new SqlParameter("@Collection1", string1));
    
        using (var myData = new SqlDataAdapter()) 
        {
            myData.SelectCommand = myCommand;
            myConnection.Open();
            
            var myytab = new DataTable();
            myydata.Fill(myytab);
        }
    }

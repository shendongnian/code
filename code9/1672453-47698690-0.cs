    String connString;
    connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Z\Desktop\Comp\MyWebsite\WorkDatabase.mdb";
    OleDbConnection myConnection = new  OleDbConnection(connString);
    myConnection.Open();
    string myQuery = "INSERT INTO Parent([Username], [FirstName], [Surname], [Email], [Mobile], [Postcode], [Password]) values('" + Usernametb.Text + "','" + Firsttnametb.Text + "','" + Surnametb.Text + "','" + Emailtb.Text + "','" + Mobiletb.Text + "','" + Postcodetb.Text + "','" + Passwordtb.Text + "')";
    OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
    myCommand.ExecuteNonQuery();
    
    try
    {
    	myCommand.ExecuteNonQuery();
    	SuccReglbl.Text = "successful registration";
    }
    catch (Exception ex)
    {
        SuccReglbl.Text = "Exception in DBHandler" + ex;
    }
    finally
    {
    
    }
    
    myCommand.ExecuteNonQuery();
    OleDbDataReader myReader = myCommand.ExecuteReader();
    while (myReader.Read())
    {
    
    }
    myConnection.Close();

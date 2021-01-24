    string myQuery = "INSERT INTO Parent([Username], [FirstName], [Surname], [Email], [Mobile], [Postcode], [Password]) values('" + Usernametb.Text + "','" + Firsttnametb.Text + "','" + Surnametb.Text + "','" + Emailtb.Text + "','" + Mobiletb.Text + "','" + Postcodetb.Text + "','" + Passwordtb.Text + "')";
    string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Z\Desktop\Comp\MyWebsite\WorkDatabase.mdb";
    try
    {
    	using(OleDbConnection myConnection = new  OleDbConnection(connString))
    	{
    		using(OleDbCommand myCommand = myConnection.CreateCommand())
    		{
    			myCommand.CommandText = myQuery;
    			myConnection.Open();
    			myCommmand.ExecuteNonQuery();
    			SuccReglbl.Text = "successful registration";
    		}
    	}
    }
    catch (Exception ex)
    {
        SuccReglbl.Text = "Exception in DBHandler " + ex.Message;
    }

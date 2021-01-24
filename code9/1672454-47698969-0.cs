            OleDbConnection myConnection = new
                OleDbConnection(connString);
            myConnection.Open();
            string myQuery = "INSERT INTO Parent([Username], [FirstName], [Surname], [Email], [Mobile], [Postcode], [Password]) values('" + Usernametb.Text + "','" + Firsttnametb.Text + "','" + Surnametb.Text + "','" + Emailtb.Text + "','" + Mobiletb.Text + "','" + Postcodetb.Text + "','" + Passwordtb.Text + "')";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
                        
            myCommand.ExecuteNonQuery();
            
            try
            {
                using (myConnection)
                {
                    myCommand.ExecuteNonQuery();
                    SuccReglbl.Text = "successful registration";
                }
            }
            catch (Exception ex)
            {
                SuccReglbl.Text = "Exception in DBHandler" + ex;
            }
            finally
            {
                myConnection.Close();
            }
             OleDbDataReader myReader = myCommand.ExecuteReader();
             while (myReader.Read())
             {
             }

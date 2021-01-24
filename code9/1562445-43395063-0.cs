    try
     {
      OleDbConnection delConn = new 
          OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data 
          Source=C:/NavneethCollection.accdb;Persist Security Info=False;");
      delConn.Open();
      String delQuery = "DELETE FROM NavColl WHERE [CusName]= @CustName";
      OleDbCommand delcmd = new OleDbCommand();
      delcmd.CommandText = delQuery;
      delcmd.Connection = delConn;
      delcmd.Parameters.AddWithValue("@CustName", textBox4.Text);
      delcmd.ExecuteNonQuery();
      MessageBox.Show("Customer has been successfully removed!");
     }
     catch(Exception exc)
     {
      MessageBox.Show("Error: "+exc.Message);
     }

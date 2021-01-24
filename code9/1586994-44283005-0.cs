    private void trydb() {
        try
        {
           myCon.Open;
           SqlDataAdapter MyDataAdapter = new SqlDataAdapter("select * from Logindata where username '" +Usertext.Text+ "' and password '" +Passtext.Text+"' ;", myCon);
            DataTable logicaldb = new DataTable();
            MyDataAdapter.Fill(logicaldb);
            //rest of your code here
        }
        catch
        {
          //exception code here
        }
       }

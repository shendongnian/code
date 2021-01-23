    string strConn =@"Server=.\SQLExpress;AttachDbFilename=|DataDirectory|Database.mdf;Database=dbname; Trusted_Connection=Yes;";
     
    using (SqlConnection myConn = new SqlConnection(strConn))
    {
      string strSQL = "INSERT INTO dbo.member (Id, Password, Name, Jobtitle,level,phone) VALUES ('a01', '123', 'bobo', 'Tester','1','010919')";
      myConn.Open();
      using(SqlCommand myCommand = new SqlCommand(strSQL, myConn))
      {
        myCommand.ExecuteNonQuery(); // you haven't execute the insert 
      }
    }

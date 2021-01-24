    using (SqlCommand sqlCom = new SqlCommand("INSERT INTO UserActivations VALUES(@UserId, @ActivationCode)"))
    { 
       sqlCom.Parameters.Add("@UserId",SqlDbType.VarChar,30).Value=userId; 
       sqlCom.Parameters.Add("@ActivationCode",SqlDbType.VarChar,30).Value=activationCode;
       sqlCom.Connection = sqlConn;
       sqlConn.Open();
       //here it is
       sqlCom.ExecuteNonQuery();
       sqlConn.Close();               
    }

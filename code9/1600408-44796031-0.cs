    using ( OracleConnection con = new OracleConnection(oradb) ) {
       con.Open();
       OracleCommand cmd1 = new OracleCommand(getSystime, con);
       using ( OracleDataReader dr1 = cmd1.ExecuteReader() ) {
          dr1.Read();
          ...
          dr1.Close();
       }
    }

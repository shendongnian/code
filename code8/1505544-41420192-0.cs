    using (var con = new OracleConnection(conStr))
    { 
       using (var scope = new TransactionScope()){
          int rows;
          using (var updcmd = new OrcaleCommand(updCmdText, con)){
             ...
             rows = updcmd.ExecuteNonQuery();
          }
          if (rows == 0) {
             using (var insertcmd = new OrcaleCommand(insertCmdTxt, con)){
             
             }
          }
          scope.Completer();
       }
    }

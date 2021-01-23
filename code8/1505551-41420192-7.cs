    String updCmdTxt = "UPDATE ....";
    String insertCmdTxt = "INSERT ....";
    using (var scope = new TransactionScope())
    { 
       using (var con = new OracleConnection(conStr)){
          int rows;
          using (var updcmd = new OracleCommand(updCmdTxt, con)){
             //Set parameters ...
             rows = updcmd.ExecuteNonQuery();
          }
          //If update command did not affect any rows, insert
          if (rows == 0) {
             using (var insertcmd = new OracleCommand(insertCmdTxt, con)){
                // Set parameters...
                insertcmd.ExecuteNonQuery();
             }
          }
          scope.Complete();
       }
    }

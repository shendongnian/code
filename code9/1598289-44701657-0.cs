    var ReturnValue=0;
    var KeyNo=0;
    while (lSqlDataReader.Read())
      {
       ReturnValue=lSqlDataReader.GetInt("Return Value");
       KeyNo=lSqlDataReader.GetInt("KeyNo");
      }

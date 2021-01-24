    SqlCommand _insertCmd;
    void InitCommands()
    { 
  
        _connectionString = 
              ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        var query = "Insert into MoHE_Student values (@name,@surname,...";
        var cmd = new SqlCommand(query);
        cmd.Parameters.Add("@name",SqlDbType.NVarChar,30);
        cmd.Parameters.Add("@surname",SqlDbType.NVarChar,30);
        ...
        _insertCmd=cmd;
    }

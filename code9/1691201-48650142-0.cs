     con.Open();
     OracleCommand  cmd= CreateCommand();
     cmd.CommandText = $@"INSERT INTO {"Customer".GetDoubleQuoted()(
            {"City".GetDoubleQuoted()},
            {"CompanyName".GetDoubleQuoted()},
            {"ContactName".GetDoubleQuoted()},
            {"Country".GetDoubleQuoted()},
            {"CustomerID".GetDoubleQuoted()},
            {"Phone".GetDoubleQuoted()}
         ) VALUES ('Chicago', 'Amisys','Jwk', 'USA','aaa', '123456')
         Returning {"City".GetDoubleQuoted()} into :city";
     cmd.Connection = con;
     cmd.Parameters.Add(new OracleParameter
         {
             ParameterName = ":city",
             OracleDbType = OracleDbType.Varchar2,
             Size = 32000,
             Direction = ParameterDirection.ReturnValue
         });
     cmd.ExecuteNonQuery();
     var value= cmd.Parameters[":city"].Value.ToString();

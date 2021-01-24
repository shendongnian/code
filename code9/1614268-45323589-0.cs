     SqlConnection connection = new 
     SqlConnection(ConfigurationManager.AppSettings["SQLConnectionString"]);
     SqlCommand command = new SqlCommand();
     command.CommandTimeout = 1000;
     command.Connection = connection;
     command.CommandType = CommandType.StoredProcedure;
     command.CommandText = "KULLANICI_OKU";
     SqlParameter parameter = new SqlParameter();
     parameter.Direction = ParameterDirection.Input;
     parameter.ParameterName = "@KULLANICI";
     parameter.DbType = DbType.String;
     parameter.Value = user;
     command.Parameters.Add(parameter);

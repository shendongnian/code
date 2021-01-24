      public class ParameterTvp : SqlMapper.IDynamicParameters
      {
          private readonly IEnumerable<string> _parameters;
    	  
          public ParameterTvp(IEnumerable<string> parameters)
          {
              _parameters = parameters;
          }
    	  
          public void AddParameters(IDbCommand command, SqlMapper.Identity identity)
          {
              var sqlCommand = (SqlCommand) command;
              sqlCommand.CommandType = CommandType.StoredProcedure;
              var items = new List<SqlDataRecord>();
              foreach (var param in _parameters)
              {
                  var rec = new SqlDataRecord(new SqlMetaData("Parameter", SqlDbType.NVarChar, 100));
                  rec.SetString(0, param);
                  items.Add(rec);
              }
    		  
              var p = sqlCommand.Parameters.Add("@param", SqlDbType.Structured);
              p.Direction = ParameterDirection.Input;
              p.TypeName = "ParameterTableType";
              p.Value = items;
          }
      }

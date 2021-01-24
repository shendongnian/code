    var parameter = new SqlParameter();
                parameter.ParameterName = "@paramName";
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                //parameter.IsNullable = true;
                parameter.Value = DaysInStock;

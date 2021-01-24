            using (var connection = (db as DbContext).Database.Connection)
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "sp_executesql";
                    command.CommandType = CommandType.StoredProcedure;
                    var param = command.CreateParameter();
                    param.ParameterName = "@statement";
                    param.Value = @"
    CREATE LOGIN readonlyLogin WITH PASSWORD='testpassword'
    CREATE USER readonlyUser FROM LOGIN readonlyLogin
    EXEC sp_addrolemember 'db_datareader', 'readonlyUser';
                    ";
                    command.Parameters.Add(param);
                    connection.Open();
                    try { 
                        command.ExecuteNonQuery();
                    } catch (SqlException ex) {     // user already exists
                        if (ex.Errors[0].Number.Equals(15025)) { } else throw ex;
                    }
                }
            }

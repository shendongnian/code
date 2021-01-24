        /// <summary>
        /// Selects the first item in the query's result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inStoredProcedure">The in stored procedure.</param>
        /// <param name="inParameters">The in parameters.</param>
        /// <returns>The first object in the specified type T.</returns>
        protected T SelectScalar<T>(string inStoredProcedure, ICollection<SqlParameter> inParameters = null)
        {            
            using (System.Data.IDbCommand command = Database.Connection.CreateCommand())
            {
                try
                {                   
                    command.CommandText = inStoredProcedure;
                    command.CommandTimeout = command.Connection.ConnectionTimeout;
                    if(inParameters != null &&  inParameters.Count > 0)
                    {
                        string paramNames = string.Join(",", inParameters.Select(parameter => parameter.ParameterName).ToList());
                        command.CommandText += " " + paramNames;
                        foreach (var param in inParameters)
                        {
                            command.Parameters.Add(param);
                        }
                    }
                    Database.Connection.Open();
                    return (T)command.ExecuteScalar();
                }
                finally
                {
                    Database.Connection.Close();
                    command.Parameters.Clear();
                }
            }
        }

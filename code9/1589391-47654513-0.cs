        /// <summary>
        ///     Calls a stored procedure that returns data as "FOR JSON AUTO" and stores the results into a temporary file.
        /// </summary>
        /// <param name="connection">SQLConnection to execute the stored procedure on.</param>
        /// <param name="commandTextForJsonQuery">CommandText for the execution.</param>
        /// <param name="parameters">All input and output parameters.</param>
        /// <param name="optionalFilePathAndName">
        ///     Optional file name and path to write to. If not specified, a Temp file will be created.
        ///     If specified but the file does not exist, the file will be created. If it exists, it will first be deleted and all
        ///     contents will be lost.
        /// </param>
        /// <param name="commandTimeoutInSeconds">CommandTimeout to use with execution.</param>
        /// <returns>Returns the filename and path with the data in it.</returns>
        private static async Task<string> CallJsonQueryAndSaveToFile(SqlConnection connection, string commandTextForJsonQuery, SqlParameter[] parameters, string optionalFilePathAndName, int commandTimeoutInSeconds)
        {
            var needsToCloseConnection = false;
            optionalFilePathAndName = string.IsNullOrWhiteSpace(optionalFilePathAndName)
                                          ? Path.GetTempFileName()
                                          : optionalFilePathAndName;
            if (File.Exists(optionalFilePathAndName))
            {
                File.Delete(optionalFilePathAndName);
            }
            using (var file = File.AppendText(optionalFilePathAndName))
            {
                using (var command = new SqlCommand(commandTextForJsonQuery, connection)
                                     {
                                         CommandTimeout = commandTimeoutInSeconds,
                                         CommandType = CommandType.Text
                                     })
                {
                    command.Parameters.AddRange(parameters);
                    try
                    {
                        if (connection.State != ConnectionState.Open)
                        {
                            needsToCloseConnection = true;
                            connection.Open();
                        }
                        using (var reader = command.ExecuteReader())
                        {
                            while (await reader.ReadAsync())
                            {
                                await file.WriteAsync(reader.GetString(0));
                            }
                        }
                    }
                    finally
                    {
                        if (needsToCloseConnection)
                        {
                            connection.Close();
                        }
                    }
                }
            }
            return optionalFilePathAndName;
        }
    }

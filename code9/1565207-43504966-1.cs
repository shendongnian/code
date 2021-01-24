        private byte[] GetFileContent(Guid fileId, int contentLength)
        {
            int outputSize = 1048576;
            int bufferSize = contentLength + outputSize;
            byte[] content = new byte[bufferSize];
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandTimeout = 300;
                    sqlCommand.CommandText = $"SELECT Content FROM dbo.[File] WHERE FileId = '{fileId}'";
                    sqlConnection.Open();
                    using (SqlDataReader reader = sqlCommand.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        while (reader.Read())
                        {
                            int startIndex = 0;
                            long returnValue = reader.GetBytes(0, startIndex, content, startIndex, outputSize);
                            while (returnValue == outputSize)
                            {
                                startIndex += outputSize;
                                returnValue = reader.GetBytes(0, startIndex, content, startIndex, outputSize);
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            return content;
        }

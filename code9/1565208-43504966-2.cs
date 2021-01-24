		public File GetFileViaFileIdGuid(Guid fileId)
        {
            File file = new File();
            string connectionString = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            using (var sourceSqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sourceSqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = $"SELECT FileName, FileExtension, UploadedDateTime, DATALENGTH(Content) as [ContentLength] FROM dbo.[File] WHERE FileId = '{fileId}'";
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandTimeout = 300;
                    sourceSqlConnection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        file.FileId = fileId;
                        file.FileExtension = reader["FileExtension"].ToString();
                        file.FileName = reader["FileName"].ToString();
                        file.UploadedDateTime = (DateTime)reader["UploadedDateTime"];
                        file.Content = new byte[Convert.ToInt32(reader["ContentLength"])];
                    }
                    
                    reader.Close();
                    sourceSqlConnection.Close();
                }
            }
            file.Content = GetFileContent(file.FileId, file.Content.Length);
            return file;
        }

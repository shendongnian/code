    public static void databaseFilePut(MemoryStream file, string fileName) 
    {
       int varID = 0;
       byte[] file = fileToPut.ToArray();
       const string preparedCommand = 
                  @"INSERT INTO [dbo].[Table]
                                   ([RaportPlik])
                             VALUES
                                   (@FileName, @File)";
       using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
            using (var sqlWrite = new SqlCommand(preparedCommand, varConnection)) {
                sqlWrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
                sqlWrite.Parameters.Add("@FileName", SqlDbType.VarChar, file.Length).Value = fileName;
                 sqlWrite.ExecuteScalar();
            }
        }

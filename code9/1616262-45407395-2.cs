    public static void databaseFilePut(string varFilePath) {
        byte[] file;
        using (var stream = new FileStream(varFilePath, FileMode.Open, FileAccess.Read)) {
            using (var reader = new BinaryReader(stream)) {
                file = reader.ReadBytes((int) stream.Length);       
            }          
        }
        using (var varConnection = Locale.sqlConnectOneTime(Locale.sqlDataConnectionDetails))
        using (var sqlWrite = new SqlCommand("insert into [table] values(@FileName, @File, '', '', '', '')", varConnection)) {
            sqlWrite.Parameters.Add("@File", SqlDbType.VarBinary, file.Length).Value = file;
            sqlWrite.Parameters.Add("@FileName", SqlDbType.VarChar, file.Length).Value = Path.GetFileName(varFilePath);
            sqlWrite.ExecuteNonQuery();
        }
    }

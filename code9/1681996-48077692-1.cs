    public bool DoesFolderAlreadyExistInTable(string folder_name, string path, OleDbConnection connection)
    {
        using (var ListWrite = new OleDbCommand("select count(*) as c from Project where name=@name and path=@path", connection)) {
            ListWrite.Parameters.AddWithValue("@name", folder_name);
            ListWrite.Parameters.AddWithValue("@path", path);
            var result = ListWrite.ExecuteReader();
            return result.Read() && result.GetInt32(0) > 0;
        }
    }

    static void Main(string[] args)
    {
        const string baseFolder = "\\gpvmsrv01\\INPUT\\Scan\\Patent\\";
        const string query =
            "INSERT INTO Patent([app_number], [type], [filename], [data]) " +
            "VALUES ({0}, {1}, {2}, {3})"
        ;
        var fileList = Directory
            .EnumerateFiles(baseFolder, "*", SearchOption.AllDirectories)
            .ToArray()
        ;
        using (var conn = new SqlConnection("your connection string goes here"))
        using (var cmd = conn.CreateCommand())
        {
            foreach (var fileX in fileList)
            {
                var parts = fileX.Substring(baseFolder.Length).Split('\\');
                // extract only the number
                var appNum = Regex.Replace(parts[2], "[^0-9]", string.Empty); 
                var typ = parts[3];
                var fn = parts[4];
                var contents = File.ReadAllBytes(fileX);
                cmd.CommandText = string.Format(query, appNum, typ, fn, contents) + Environment.NewLine;
            }
            cmd.ExecuteNonQuery();
        }
    }

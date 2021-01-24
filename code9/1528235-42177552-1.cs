    private static void WriteReleaseSql( string sqlStatement)
    {
        string ReleaseoutputFilePath = ConfigurationManager.AppSettings["ReleaseOutputFilePath"];
        using (StreamWriter sw = new StreamWriter(ReleaseoutputFilePath,True))
        {
            sw.WriteLine(sqlStatement);
        }
    }

    public static int IsSsasAccessibleToUser(string ssasServerName)
    {
        var hasAccess = 0;
        try
        {
            using (var adomdConnection = new AdomdConnection($"provider=olap;datasource={ssasServerName};Catalog=myDatabaseName"))
            using (var adomdCommand = new AdomdCommand())
            {
                adomdCommand.CommandText = "SELECT [CATALOG_NAME] AS [DATABASE],CUBE_CAPTION AS [CUBE/PERSPECTIVE],BASE_CUBE_NAME FROM $system.MDSchema_Cubes WHERE CUBE_SOURCE = 1";
                adomdCommand.Connection = adomdConnection;
                adomdConnection.Open();
                adomdCommand.ExecuteNonQuery();
                Log("ExecuteNonQuery call succeeded so the user has access");
                hasAccess = 1;
            }
        }
        catch (Exception ex)
        {
            Log("There was an error firing query on the database in SSAS server. so user doesn't have access");
        }
        return hasAccess;
    }

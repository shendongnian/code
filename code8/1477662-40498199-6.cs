    public static string GetDBConnectionString(string dataParentPath = "")
    {
        EntityConnectionStringBuilder entityBuilder = new EntityConnectionStringBuilder();
        SqlCeConnectionStringBuilder sqlCEBuilder = new SqlCeConnectionStringBuilder();
        if (string.IsNullOrEmpty(dataParentPath) == true)
            dataParentPath = @"C:\MyDBFolder\CMS.sdf";
        sqlCEBuilder.DataSource = dataParentPath;
        sqlCEBuilder.Password = "12345687";
        sqlCEBuilder.MaxDatabaseSize = 4090;
        entityBuilder.Metadata = "res://*/CMS.csdl|res://*/CMS.ssdl|res://*/CMS.msl";
        entityBuilder.ProviderConnectionString = sqlCEBuilder.ToString();
        entityBuilder.Provider = "System.Data.SqlServerCe.4.0";
        return entityBuilder.ToString();
    }

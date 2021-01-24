    var assembly = Assembly.GetExecutingAssembly();
    string resourceName = typeof(RunSqlScript).Namespace + ".20191220105024_RunSqlScript.sql";
    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
    {
      using (StreamReader reader = new StreamReader(stream))
      {
        string sqlResult = reader.ReadToEnd();
        migrationBuilder.Sql(sqlResult);
      }
    }

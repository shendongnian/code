    protected override void Seed({DbContextType} context)
    {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        var baseDir = Path.GetDirectoryName(path) + "\\Migrations\\{CreateViewSQLScriptFilename}.sql";
 
        context.Database.ExecuteSqlCommand(File.ReadAllText(baseDir));
    }

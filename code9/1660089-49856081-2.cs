    [Fact]
    public void AccessAppSettings_ConnectionString()
    {
         //obtain the current directory for the executable
         Uri UriAssemblyFolder = new Uri(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly()
                                               .GetName().CodeBase));
         string appPath = UriAssemblyFolder.LocalPath;
         //Change the "DataProvider.Tests.dll" to whatever your 
         //library or executable name. 
         //Note: Configuration manager will add the .config extension
         Configuration config = ConfigurationManager
                .OpenExeConfiguration(appPath + @"\" + "DataProvider.Tests.dll");
         ConnectionStringsSection section = 
                      config.GetSection("connectionStrings") as ConnectionStringsSection;
         string expectedString = $"Data Source=mysqliteDBName.sqlite3";
         //Change "mySqliteConnectionString" to your connection string name   
         var sut_connectionString = 
                     section.ConnectionStrings ["mySqliteConnectionString"].ConnectionString;
            
          Assert.NotNull(sut_connectionString);
          Assert.Contains(expectedString, sut_connectionString);

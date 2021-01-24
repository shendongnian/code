    string test = "metadata=res://*/model.csdl|res://*/model.ssdl|res://*/model.msl;provider=System.Data.SqlClient;provider connection string=\"data source = myDESKTOP; initial catalog = dbName; integrated security = True; MultipleActiveResultSets = True; App = EntityFramework";
    string con = string.Join("=", 
                        string.Join(";", test.Split(';').Skip(2))
                              .Split('=').Skip(1)).Trim('"');
    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(con);
    Console.WriteLine(sb.DataSource);
    Console.WriteLine(sb.InitialCatalog);

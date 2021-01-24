     DataTable dbTables = new DataTable();
     SqlDataAdapter adap;
     SqlConnection connection = new SqlConnection("yourConnectionString");            
     SqlCommand cmd = new SqlCommand(@"SELECT name FROM master.dbo.sysdatabases ", connection);           
      adap = new SqlDataAdapter(cmd);
      adap.Fill(dbTables);
      string[] dbTableNames = dbTables.AsEnumerable().Select(x => x.Field<string>("name")).ToArray();
       
      string[] diff = files.Except(dbTableNames).ToArray(); // one of pssibility to check differents

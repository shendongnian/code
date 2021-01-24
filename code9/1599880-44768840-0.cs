      <connectionStrings>
        <add name="Connection" connectionString="Data Source=k:\Temp; xtended Properties=dBase IV Provider=Microsoft.Jet.OLEDB.4.0" />    
      </connectionStrings>
    
                
    string connection = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
               using (OleDbConnection dBaseConnection = new OleDbConnection(connection))
               {
                   if (dBaseConnection.State == ConnectionState.Closed)
                   {
                       dBaseConnection.Open();
                   }
               }

    string command = "select stuff from mydata";
    string connection = GetConnectionStringFromEncryptedConfigFile();
    
        using (var conn = new SqlConnection(connection))
        {
          using (var cmd = new SqlCommand(command, conn))
           {
              cmd.Connection.Open();
              //do stuff            
           }
        }

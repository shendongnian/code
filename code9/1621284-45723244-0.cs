     string myConnectionString = "your-connectionstring-goes-here";
        try{
            using (var con = new MySqlConnection { ConnectionString = myConnectionString }){
                con.Open();
    
                if (!con.Ping()){
                    System.Diagnostics.Trace.TraceError("MySQL Ping Failed:");
                }
                else{
                    System.Diagnostics.Trace.TraceInformation("MySQL Successfull");
                }
            }
        }
        catch (Exception exep){
            System.Diagnostics.Trace.TraceError("Could not connect to MySQL: " + exep.Message);
        }

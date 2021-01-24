    var connString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;
        using (var connection = new SqlConnection(connString)) {
            foreach(var product in CSVProducts){        
                connection.Insert(product);
            }
        }

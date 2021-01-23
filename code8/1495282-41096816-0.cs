    MySqlConnection objcon = new MySqlConnection(databasekoplingsadresse_devart());
    MySqlCommand cmdMsg = new MySqlCommand("select * from messages", objcon); 
    MySqlCommand cmdTasks = new MySqlCommand("select * from tasks", objcon); 
    
    MySqlDependency dependency = new MySqlDependency(cmdMsg, 100); 
    dependency.AddCommandDependency(cmdTasks); 
    dependency.OnChange += Dept_OnChange2
    MySqlDependency.Start(objcon.Connection.ConnectionString); 

     List<string> list = new List<string> { 
       "listItem1", "listItem2", "listItem3" };
     command.CommandText = "INSERT INTO table (item) VALUES (@ListItem);";
     // Declare parameter once ...
     //TODO: specify parameter's value type as a second argument
     command.Parameters.Add("@ListItem");
     foreach (var item in list) {
       // ...use many
       command.Parameters[0].Value = item;
       command.ExecuteNonQuery();
     }

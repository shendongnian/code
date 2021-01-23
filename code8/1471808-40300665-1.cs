    var connBuilder = new SqlConnectionStringBuilder();
    connBuilder.DataSource = "localhost";
    connBuilder.InitialCatalog = "YourDatabaseName";
    connBuilder.IntegratedSecurity = true;
    using (var con = new SqlConnection(connBuilder.ToString()))
    {
        con.Open();
        var list = new List<Menu>();                
        //pull data from database               
        using (var cmd = con.CreateCommand())
        {
            cmd.CommandText = "SELECT Id, Title, Parent FROM [dbo].[YourTableName]";
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    list.Add(new Menu
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Parent = reader.IsDBNull(2) ?(int?) null : reader.GetInt32(2)
                    });
                }
            }
        }
        //construct tree
        var newList = new List<Menu>();
        foreach (var l1 in list)
        {
            if (l1.Parent == null)
            {
                newList.Add(l1);
            }
            foreach (var l2 in list)
            {
                if (l2.Parent == l1.Id)
                {
                    l1.Children.Add(l2);
                }
            }
        }
        // do whatever you want with newList
    }

    var emailQuery = 
        @"SELECT [User] ,[Login] ,[number1] ,[number2] ,[number3] ,[Alertcount] 
        FROM Users.dbo.[Email] 
        WHERE [Alertcount] = 1 
            AND [Alertcount] !=2"; // Useless condition, because Alertcount already = 1
    using(var connection2 = new SqlConnection("Data Source = *** "))
    using(var adapter2 = new SqlDataAdapter(emailQuery, connection1))
    {
        var data2 = new DataTable();
        adapter2.Fill(data2);
        dataGridView2.DataSource = data2;
    }
    var actionsQuery = 
        @"SELECT [User] ,[Login] ,[Attempt] 
        FROM User.dbo.Actions 
        WHERE Attempt > @Mine AND Attempt < @Mine2";
    foreach (var row in dataGridView2.Rows)
    {
        var mine = (int)row.Cells["number1"].Value; // it is already integer, just cast it
        var mine2 = (int)row.Cells["number3"].Value;
        using(var connection1 = new SqlConnection("Data Source = *** "))
        using(var adapter1 = new SqlDataAdapter(actionsQuery, connection1))
        {
            var parameters = new[]
            {
                new SqlParameter
                {
                    ParameterName = "@Mine",
                    SqlDbType = SqlDbType.Int,
                    Value = mine
                },
                new SqlParameter
                {
                    ParameterName = "@Mine2",
                    SqlDbType = SqlDbType.Int,
                    Value = mine2
                }
            };
            adapter1.SelectCommand.Parameters.AddRange(parameters);
            var data1 = new DataTable();
            adapter.Fill(data1);
            dataGridView1.DataSource = data1
        }        
    }

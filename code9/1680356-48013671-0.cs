    var dataset = new DataSet();
    using(var cnnn = new SqlConnection(cnnString))
    {
        var adapter = new SqlDataAdapter();
        adapter.SelectCommand = new SqlCommand("dbo.Search_", cnnn);
        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        adapter.Fill(dataset);
    }
    dataset.Tables => gives u all the results of exec(@sql)
    

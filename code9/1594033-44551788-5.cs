    private void DataGrid_Loaded(object sender, RoutedEventArgs e)
    {
        SqlConnection sqlConnection1 = new SqlConnection("Your Connection String");
        sqlConnection1.Open();
        SqlCommand cmd = new SqlCommand("SELECT Visitors.VisitorName,  Countries.CountryName FROM Visitors INNER JOIN Countries ON Visitors.CountryID = Countries.CountryID; ", sqlConnection1);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        var DataSet = new DataSet();
        da.Fill(DataSet);
      
        var GridList = DataSet.Tables[0].AsEnumerable().ToList();
        
        // ... Assign ItemsSource of DataGrid.
        var grid = sender as DataGrid;
        grid.ItemsSource = GridList;
    }
    

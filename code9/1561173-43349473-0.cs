    private async void UserControl_Loaded(object sender, RoutedEventArgs e)
    {
        try
        {
            prg2.Visibility = Visibility.Visible;
    		
        	dataGrid1.itemsSource = await GetDataAsync();
    
        	prg2.Visibility = Visibility.Hidden; 
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    private Task<DataView> GetDataAsync()
    {
    	return Task.Run(()=>
    	{
    		using (var con = new SqlConnection(connectionstring))
    		{
    		    con.Open();
    
    		    var dt = new DataTable();
    		    var cmd= new SqlCommand("Select ...", con);
    		    cmd.CommandTimeout = 0;
    
    		    var dadapt = new SqlDataAdapter();
    		    dadapt.Fill(dt); 
    
    		    return dt.DefaultView;	
    		}
    	});
    }

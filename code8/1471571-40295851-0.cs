    public Apartment()
    {
        InitializeComponent();
    }
    SqlConnection con = new SqlConnection(Connection.cnnDatabase1);
    Database1DataSet ds = new Database1DataSet();
    private void FillLocation()
    {
        //locationCombo.Items.Clear() 
        SqlDataAdapter daLocation= new SqlDataAdapter("select * from Location", con);
		ds.Tables["Location"].Clear();
		
        daLocation.Fill(ds, "Location");
        con.Open();
        locationCombo.ItemsSource = ds.Tables["Location"].DefaultView;
        locationCombo.DisplayMemberPath = "Location";
        locationCombo.SelectedValuePath = "IdLocation";
        con.Close();
    }
    private void FillCity(String IdLocation)
    {
        /*cityCombo.Items.Clear() -- I have tried inserting this, 
        but I am getting an error "Operation is not valid while ItemsSource is in use. 
        Access and modify elements with ItemsControl.ItemsSource instead." on that part 
        when I reselect the combo.*/
		if(!String.IsNullOrWhiteSpace(IdLocation))
		{
			ds.Tables["City"].Clear();
			SqlDataAdapter daCity= new SqlDataAdapter("select * from City where IdLocation= " + IdLocation, con);
			daCity.Fill(ds, "City");
			con.Open();
			cityCombo.ItemsSource = ds.Tables["City"].DefaultView;
			cityCombo.DisplayMemberPath = "City";
			cityCombo.SelectedValuePath = "IdCity";
			con.Close();
		}
    }
    private void FillStreet(String IdCity)
    {
        if(!String.IsNullOrWhiteSpace(IdCity))
		{
			s.Tables["Street"].Clear();
			SqlDataAdapter daStreet= new SqlDataAdapter("select * from Street where IdCity= " + IdCity, con);
			daStreet.Fill(ds, "Street");
			con.Open();
			cityCombo.ItemsSource = ds.Tables["Street"].DefaultView;
			cityCombo.DisplayMemberPath = "Street";
			cityCombo.SelectedValuePath = "IdStreet";
			con.Close();
		}
    }
	private void Window_Loaded_1(object sender, RoutedEventArgs e)
    {
        FillLocation();
    }
    private void locationCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if(locationCombo.SelectedValue != null)
		{
			String idLocation= locationCombo.SelectedValue.ToString();
			FillCity(idLocation);
		}
    }
    private void cityCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if(cityCombo.SelectedValue != null)
		{
			String idCity = cityCombo.SelectedValue.ToString();
			FillStreet(idCity);
		}
    }

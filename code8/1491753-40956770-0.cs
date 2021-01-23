    TextView FCompStock;
    protected override void OnCreate(Bundle bundle)
    {
        //Not showing you lots of stuff, because its irrelevant
        Spinner RiderSelectSpinner = FindViewById<Spinner>(Resource.Id.RiderSelectSpinner);
        FCompStock = FindViewById<TextView>(Resource.Id.FCompStock);
    
        RiderSelectSpinner.ItemSelected += rider_Selected;
    }
    
    public void rider_Selected(object sender, AdapterView.ItemSelectedEventArgs e) {
        //Not showing you many database things because its not relevant
    
        if (!string.IsNullOrEmpty(dataString))
        {
            string[] dataList = dataString.Split(',');
            FCompStock.Text = "Whatever you want";
        }
    }

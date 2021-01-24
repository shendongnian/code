    List<string> items;
    
    
    protected override void OnCreate (Bundle savedInstanceState)
    {
        base.OnCreate (savedInstanceState);
        SetContentView (Resource.Layout.Main);
        ....
    
        items = new List<string> (savedItems) {"1", "2", "3"};
        _spinnerAdapter = new ArrayAdapter<string> (this, Android.Resource.Layout.SimpleSpinnerItem, items);
        spinner.Adapter = _spinnerAdapter;    
  
        button5.Click += delegate {
             // To remove the selected item, first remove the selected item from the list, then call NotifyDataSetChanged
             items.remove(spinner.SelectedItem.ToString ());
             _spinnerAdapter.NotifyDataSetChanged ();
        };
    
    }
    

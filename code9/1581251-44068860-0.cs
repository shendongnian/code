    protected override async void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
    
        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.Main);
        ActionBar.Hide();
    
        btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
        //Notes
        notesList = FindViewById<ListView>(Resource.Id.lvNotes);
    
    
        //Where I am trying to call the method...
         await CopyAssetAsync(activity);
    }

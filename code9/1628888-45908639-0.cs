    EditText ipadd;
    
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.Main);
        Button btnConnectClick = FindViewById<Button>(Resource.Id.btnConnect);.
        ipadd = FindViewById<EditText>(Resource.Id.ipadd); // Create object of textbox
        btnConnectClick.Click += BtnConnectClick_Click;
    }

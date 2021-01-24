    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.Main);
        Xamarin.Forms.Forms.Init(this.ApplicationContext, savedInstanceState);
        signatureView = new SignaturePadView(this);
        signatureView.StrokeWidth = 4;
        LinearLayout signatureLayout = (LinearLayout)FindViewById(Resource.Id.signatureLayout);
        signatureLayout.AddView(signatureView);
        Button btnSave = FindViewById<Button>(Resource.Id.btnSave);
        btnSave.Click += (sender, e) =>
        {
            SaveInfo();
        };
    }

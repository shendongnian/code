    Button btnMain;
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        SetContentView(Resource.Layout.layout1);
        Button btn1 = (Button)FindViewById(Resource.Id.btn1);
        Button btn2 = (Button)FindViewById(Resource.Id.btn2);
        btnMain = (Button)FindViewById(Resource.Id.btnMain);
        btn1.Click += ChangeBackground;
        btn2.Click += ChangeBackground;
    }
    private void ChangeBackground(object sender, EventArgs e)
    {
        var btn = sender as Button;
        btnMain.Background = btn.Background;
    }

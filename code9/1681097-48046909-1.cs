    SfPicker picker;
    protected override void OnCreate(Bundle savedInstanceState)
    {
        picker = new SfPicker(this);
        base.OnCreate(savedInstanceState);
        ColorInfo info = new ColorInfo();
        picker.ItemsSource = info.Colors;
        picker.IsOpen = true;
        SetContentView(picker);
    }

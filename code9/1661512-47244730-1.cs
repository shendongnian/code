    [Export("cmdWelfareClicked")]
    public void cmdWelfareClicked(View v)
    {
        SetContentView(Resource.Layout.p1);
    }
    [Export("cmdSettingsClicked")]
    public void cmdSettingsClicked(View v)
    {
        v.SetBackgroundColor(Android.Graphics.Color.Azure);
    }

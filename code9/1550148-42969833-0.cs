    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
    
        RelativeLayout mlayout = new RelativeLayout(this)
        {
            LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent)
        };
    
        SeekBar sb = new SeekBar(this)
        {
            LayoutParameters = new ViewGroup.LayoutParams(900, ViewGroup.LayoutParams.WrapContent),
            Max = 255,
        };
    
        mlayout.AddView(sb);
        SetContentView(mlayout);
        sb.ProgressChanged += Sb_ProgressChanged;
    }
    
    private void Sb_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
    {
        var progress = e.Progress;
        System.Diagnostics.Debug.WriteLine(progress);
    }

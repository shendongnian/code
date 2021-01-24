    public ScrollView scview;
    
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
    
        // Create your application here
        SetContentView(Resource.Layout.layout1);
    
        scview = FindViewById<ScrollView>(Resource.Id.scrollView1);
    
        TextView tv1 = FindViewById<TextView>(Resource.Id.Text1);
        TextView tv2 = FindViewById<TextView>(Resource.Id.Text2);
        TextView tv3 = FindViewById<TextView>(Resource.Id.Text3);
    
        tv1.Click += Tv_Click;
        tv2.Click += Tv_Click;
        tv3.Click += Tv_Click;
    }
    
    private void Tv_Click(object sender, EventArgs e)
    {
        var tv = sender as TextView;
        var yoffset = tv.Top;
        scview.ScrollTo(0, yoffset);
    }

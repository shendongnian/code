	protected override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		var layoutParams = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
		var imageView = new ImageView(this)
		{
			LayoutParameters = layoutParams
		};
		imageView.SetImageResource(Resource.Drawable.splash_screen);
		imageView.SetScaleType(ImageView.ScaleType.FitCenter);
		imageView.SetBackgroundColor(Color.ParseColor("#0098CC"));
		SetContentView(imageView);
	}
	protected async override void OnResume()
	{
		base.OnResume();
        await Task.Delay(5000); // simulate some background work....
		StartActivity(typeof(MainActivity));
	}

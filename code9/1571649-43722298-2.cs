	public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
	{
		base.OnCreateOptionsMenu(menu);
		MenuInflater.Inflate(Resource.Menu.EmptyXmlFile, menu);
		return base.OnCreateOptionsMenu(menu);
	}

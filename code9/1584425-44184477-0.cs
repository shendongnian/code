    using MvvmCross.Binding.Droid.BindingContext;
    ...
	public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	{
		var ignored = base.OnCreateView(inflater, container, savedInstanceState);
		var view = this.BindingInflate(Resource.Layout.MyFragmentLayout, container, false);
		return view;
	}

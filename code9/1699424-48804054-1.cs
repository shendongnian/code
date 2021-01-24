	public class ListViewRenderer : ViewRenderer<ListView, AListView>, SwipeRefreshLayout.IOnRefreshListener
	{
        ...
		public ListViewRenderer(Context context) : base(context)
		{
			AutoPackage = false;
		}
		[Obsolete("This constructor is obsolete as of version 2.5. Please use ListViewRenderer(Context) instead.")]
		public ListViewRenderer()
		{
			AutoPackage = false;
		}

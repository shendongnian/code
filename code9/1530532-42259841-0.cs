	[Activity(Label = "PageSelectionActivity", Theme = "@style/MyTheme",  Name = "com.sushhangover.openpage.PageSelectionActivity")]
	public class PageSelectionActivity : AppCompatActivity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.PageSelection);
			Button button = FindViewById<Button>(Resource.Id.myButton);
			button.Click += delegate 
			{
				var intent = new Intent(ApplicationContext, typeof(MainActivity));
				intent.PutExtra("page", "StackOverflowPage");
				StartActivity(intent);			
			};
		}
	}

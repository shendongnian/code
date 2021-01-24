    [Activity(Label = "ActionbarClickDemo", MainLauncher = true,Theme ="@style/AppTheme")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Android.Support.V7.Widget.Toolbar myToolbar = (Android.Support.V7.Widget.Toolbar)FindViewById(Resource.Id.my_toolbar);
            SetSupportActionBar(myToolbar);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.actionbar_items, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_favorite:
                    //do something
                    break;
            }
            return base.OnOptionsItemSelected(item);
        }
    }

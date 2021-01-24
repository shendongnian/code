    public class MainActivity : Activity
    {
        ListView myListView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            myListView = FindViewById<ListView>(Resource.Id.MyListView);
            myListView.Adapter=new MyListAdapter(this,"this is my custom data");
        }
    }
 

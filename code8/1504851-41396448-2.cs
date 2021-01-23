    [Activity(Label = "CustomAdapterAndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private ListView listItems;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            listItems = FindViewById<ListView>(Resource.Id.listViewItems);
            PopulateItemsList();
        }
        private void PopulateItemsList()
        {
            listItems.Adapter = new ItemListAdapter(
               this, new List<Item>
                {
                    new Item("222", "First Sample"),
                    new Item("111", "Второй пример"),
                    new Item("333", "მესამე მანალითი")
                }); 
            
        }

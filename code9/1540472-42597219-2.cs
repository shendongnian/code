	[Activity(Label = "RecyclerViewWithRealm", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		RecyclerView recyclerView;
		RecyclerView.Adapter adapter;
		RecyclerView.LayoutManager layoutManager;
		Realm masterRealmInstance;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			masterRealmInstance = Realm.GetInstance("RecyclerViewExample.realm");
			if (masterRealmInstance.All<ARealmObject>().Count() == 0)
			{
				masterRealmInstance.Write(() => // Create some test data
				{
					for (int i = 0; i < 10000; i++)
					{
						masterRealmInstance.Add(new ARealmObject { Key = i, Caption = $"StackOverFlow # + {i.ToString()}", SeekBar1 = 50, SeekBar2 = 50 });
					}
				});
			}
			SetContentView(Resource.Layout.ARecyclerLayOut);
			recyclerView = (RecyclerView)FindViewById(Resource.Id.recyclerView);
			recyclerView.HasFixedSize = true;
			layoutManager = new LinearLayoutManager(this);
			recyclerView.SetLayoutManager(layoutManager);
			adapter = new RealmAdapter((RealmConfiguration)masterRealmInstance.Config);
			recyclerView.SetAdapter(adapter);
		}
	}

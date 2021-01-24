	public class RealmAdapter : RecyclerView.Adapter
	{
		Realm realm;
		IQueryable<ARealmObject> realmobjects;
		public RealmAdapter(RealmConfiguration config)
		{
			realm = Realm.GetInstance(config);
			realmobjects = realm.All<ARealmObject>();
		}
		public class RealmObjectViewHolder : RecyclerView.ViewHolder
		{
			readonly Timer timer;
			readonly Realm realm;
			ARealmObject aRealmObject;
			string lastCaption;
			public RealmObjectViewHolder(View view, Realm realm) : base(view)
			{
				this.realm = realm;
				Caption = view.FindViewById<TextView>(Resource.Id.realmTextView);
				SeekBar1 = view.FindViewById<SeekBar>(Resource.Id.seekBar1);
				SeekBar2 = view.FindViewById<SeekBar>(Resource.Id.seekBar2);
				SeekBar1.StopTrackingTouch += SeekBar_HandleEventHandler;
				SeekBar2.StopTrackingTouch += SeekBar_HandleEventHandler;
			}
			public TextView Caption { get; private set; }
			public SeekBar SeekBar1 { get; private set; }
			public SeekBar SeekBar2 { get; private set; }
			public int Key
			{
				get { return aRealmObject.Key; }
				set
				{
					aRealmObject = realm.Find<ARealmObject>(value);
					aRealmObject = aRealmObject ?? new ARealmObject { Key = value, Caption = $"missing key : {value}", SeekBar1 = 50, SeekBar2 = 50 };
					Caption.Text = aRealmObject.Caption;
					lastCaption = Caption.Text;
					SeekBar1.Progress = aRealmObject.SeekBar1;
					SeekBar2.Progress = aRealmObject.SeekBar2;
				}
			}
			void SeekBar_HandleEventHandler(object sender, SeekBar.StopTrackingTouchEventArgs e)
			{
				UpdateRealmObject();
			}
			void UpdateRealmObject()
			{
				if (aRealmObject.Caption != Caption.Text || aRealmObject.SeekBar1 != SeekBar1.Progress || aRealmObject.SeekBar2 != SeekBar2.Progress)
				{
					lastCaption = Caption.Text;
					realm.Write(() =>
					{
						aRealmObject.SeekBar1 = SeekBar1.Progress;
						aRealmObject.SeekBar2 = SeekBar2.Progress;
						realm.Add(aRealmObject, true); // Using the optional update: parameter set to true
					});
				}
			}
		}
		public override int ItemCount
		{
			get { return realmobjects.Count(); }
		}
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			var vh = holder as RealmObjectViewHolder;
			vh.Key = position;
		}
		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ARealmObjectCardView, parent, false);
			var vh = new RealmObjectViewHolder(itemView, realm);
			return vh;
		}
	}

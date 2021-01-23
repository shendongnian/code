	public class MainActivity : AppCompatActivity
	{
		const string customFragmentTag = "custom_fragment";
		CustomFragment frag;
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			frag = FragmentManager.FindFragmentByTag(customFragmentTag) as CustomFragment;
			if (frag == null)
			{
				frag = new CustomFragment(Resource.Layout.Frag);
				FragmentManager.BeginTransaction().Add(Resource.Id.container, frag, customFragmentTag).Commit();
			}
			frag.ButtonClick += (s, e) => SetContentView(Resource.Layout.Frag);
		}
	}

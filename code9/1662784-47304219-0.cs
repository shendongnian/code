    public class FragmentSettings : SupportFragment
    {
        private Button mBtnOk;
        public FragmentSettings(Context context)
        {
            mContext = context;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //Inflate the fragment XML
            View view = inflater.Inflate(Resource.Layout.FragmentSettings, container, false);
            //Grab the butten from the inflated fragment
            mBtnOk = view.FindViewById<Button>(Resource.Id.mBtnOk);
            mBtnOk.Click += (object sender, EventArgs e) =>
            {
                //DO stuff
            };
            
            return view;
        }
    }

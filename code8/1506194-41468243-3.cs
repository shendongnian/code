    public class MyDialogFragment : DialogFragment
    {
        private ImageView imgView;
        static public MyDialogFragment newInstance()
        {
            MyDialogFragment f = new MyDialogFragment();
            return f;
        }
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetStyle(DialogFragmentStyle.NoTitle, Android.Resource.Style.ThemeBlackNoTitleBarFullScreen);
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View v = inflater.Inflate(Resource.Layout.fragment_dialog, container, false);
            imgView = v.FindViewById<ImageView>(Resource.Id.img);
            //Get int and set it to the ImageView
            int imgPassed = Arguments.GetInt("imgId");
            imgView.SetImageResource(imgPassed);
            return v;
        }
    }

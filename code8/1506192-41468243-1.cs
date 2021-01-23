     public class MyDialogFragment : DialogFragment
        {
    
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
                View v = inflater.Inflate(Resource.Layout.fragment_dialog, container, false);
                return v;
            }
        }

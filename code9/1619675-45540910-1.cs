    public class AdaptiveFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            // Create your fragment here
        }
    
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.adaptivelayout, container, false);
            string message = this.Arguments.GetString("message");
            //create dynamically view for this fragment based on the message.
            return view;
        }
    }

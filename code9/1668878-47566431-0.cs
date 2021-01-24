        public class MainActivity : Activity, IOnScrollChangedListener
        {
        ScrollView msv;
        public void OnScrollChanged()
        {
            float scrollY = msv.ScrollX;
            float scrollX = msv.ScrollY;
            System.Diagnostics.Debug.Write("x:=" + scrollY + "  y=" + scrollX );
            //do something
        }
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            msv = FindViewById<ScrollView>(Resource.Id.sv);
            msv.ViewTreeObserver.AddOnScrollChangedListener(this);
            
        }
        }

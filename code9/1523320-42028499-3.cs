    public class MainActivity : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            SetContentView(Resource.Layout.activity_main);
            var mapView = (MapView) FindViewById(Resource.Id.mapView);
            mapView.Map = ViewModel.Map;
        }   
    }

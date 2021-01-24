     public class LocationEnabled : Fragment
    {
        public GoogleApiClient googleApiClient;
      //  static int REQUEST_LOCATION = 199;
        public const int MIN_TIME_BW_UPDATES = 1000 * 3;
        public const int REQUEST_CHECK_SETTINGS = 9000;
        AppCompatActivity _activity;
        public LocationEnabled(AppCompatActivity activity)
        {
            _activity = activity;
        }
        private bool hasGPSDevice(Context context)
        {
            LocationManager mgr = (LocationManager)context.GetSystemService(Context.LocationService);
            if (mgr == null)
                return false;
            IList<string> providers = mgr.AllProviders;
            if (providers == null)
                return false;
            return providers.Contains(LocationManager.GpsProvider);
        }
        private async void enableLoc()
        {
            if (googleApiClient == null)
            {
                googleApiClient = new GoogleApiClient.Builder(_activity)
                 .AddApi(LocationServices.API)
                 .AddConnectionCallbacks(new CallBackHelper(googleApiClient))
                 .AddOnConnectionFailedListener(new ConnectionFailedCallBack(_activity)).Build();
                googleApiClient.Connect();
                LocationRequest locationRequest = LocationRequest.Create();
                locationRequest.SetPriority(LocationRequest.PriorityHighAccuracy);
                locationRequest.SetInterval(MIN_TIME_BW_UPDATES);
                locationRequest.SetFastestInterval(MIN_TIME_BW_UPDATES/2);
                LocationSettingsRequest.Builder builder = new LocationSettingsRequest.Builder()
                  .AddLocationRequest(locationRequest);
                builder.SetAlwaysShow(true);
                LocationSettingsResult locationSettingsResult =
                 await LocationServices.SettingsApi.CheckLocationSettingsAsync(googleApiClient, builder.Build());
                switch (locationSettingsResult.Status.StatusCode)
                {
                    case LocationSettingsStatusCodes.Success:
                        Toast.MakeText(_activity, "SUCCESS", ToastLength.Short).Show();
                        break;
                    case LocationSettingsStatusCodes.ResolutionRequired:
                        try
                        {
                            locationSettingsResult.Status.StartResolutionForResult(_activity, REQUEST_CHECK_SETTINGS);
                        }
                        catch (Exception e)
                        {
                            Toast.MakeText(_activity, "CANCEL: " + e.Message, ToastLength.Short).Show();
                        }
                        break;
                    default:
                        googleApiClient.Disconnect();
                        break;
                }
            }
        }
      
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            LocationManager manager = (LocationManager)_activity.GetSystemService(Context.LocationService);
            if (manager.IsProviderEnabled(LocationManager.GpsProvider) && hasGPSDevice(_activity))
            {
                Intent intent = new Intent(_activity, typeof(GoogleMapsActivity));
                StartActivity(intent);
            }
            if (!hasGPSDevice(_activity))
            {
                  Toast.MakeText(_activity, "Gps not Supported", ToastLength.Long).Show();
            }
            if (!manager.IsProviderEnabled(LocationManager.GpsProvider) && hasGPSDevice(_activity))
            {
                enableLoc();              
            }
            else
            {
               
            }
        }
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
    public class ConnectionFailedCallBack : Java.Lang.Object, GoogleApiClient.IOnConnectionFailedListener
    {
        Context _context;
        public ConnectionFailedCallBack(Context context)
        {
            _context = context;
        }
        public void OnConnectionFailed(ConnectionResult result)
        {
            Toast.MakeText(_context, "Location connection failed.", ToastLength.Short).Show();
        }
    }
    public class CallBackHelper : Java.Lang.Object, GoogleApiClient.IConnectionCallbacks
    {
        GoogleApiClient googleApiClient;
        public CallBackHelper(GoogleApiClient googleApiClient)
        {
            this.googleApiClient = googleApiClient;
        }
        public void OnConnected(Bundle connectionHint)
        {
        }
        public void OnConnectionSuspended(int cause)
        {
            googleApiClient.Connect();
        }
    }

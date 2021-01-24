    public class GPSEnabledReceiver : BroadcastReceiver
    {
        readonly Context context;
        readonly EventHandler locationEvent;
        public GPSEnabledReceiver(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer) { }
        public GPSEnabledReceiver() {}
        public GPSEnabledReceiver(Context context, EventHandler locationEvent)
        {
            this.context = context;
            this.locationEvent = locationEvent;
        }
        public override void OnReceive(Context context, Intent intent)
        {
            if (context?.GetSystemService(LocationService) is LocationManager locationManager && locationManager.IsProviderEnabled(LocationManager.GpsProvider))
            {
                locationEvent?.Invoke(this, new EventArgs());
            }
        }
    }

    [assembly: Xamarin.Forms.Dependency(typeof(GetMyLocationStatus))]
    namespace BarberApp.Droid
    {
	public class GetMyLocationStatus: Java.Lang.Object,MyLocationTracker,ILocationListener
	{
		private LocationManager _locationManager;
		private string _locationProvider;
		private Location _currentLocation { get; set; }
	
		public GetMyLocationStatus() {
			
		this.InitializeLocationManager();
		}
		public event EventHandler<MyLocationEventArgs> locationObtained;
		event EventHandler<MyLocationEventArgs> MyLocationTracker.locationObtained
		{
			add
			{
				locationObtained += value;
			}
			remove
			{
				locationObtained -= value;
			}
		}
		void InitializeLocationManager()
		{
			_locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
		}
	
		public void OnLocationChanged(Location location)
		{
			_currentLocation = location;
		
			if (location != null)
			{
				LocationEventArgs args = new LocationEventArgs();
				args.lat = location.Latitude;
				args.lng = location.Longitude;
				locationObtained(this, args);
			}
			
		}
		
		void MyLocationTracker.ObtainMyLocation()
		{
			_locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
			if (!_locationManager.IsProviderEnabled(LocationManager.GpsProvider) || !_locationManager.IsProviderEnabled(LocationManager.NetworkProvider))
			{
				AlertDialog.Builder builder = new AlertDialog.Builder(Forms.Context);
				builder.SetTitle("Location service not active");
				builder.SetMessage("Please Enable Location Service and GPS");
				builder.SetPositiveButton("Activate", (object sender, DialogClickEventArgs e) =>
				{
				
						Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
						Forms.Context.StartActivity(intent);
				
				});
				Dialog alertDailog = builder.Create();
				alertDailog.SetCanceledOnTouchOutside(false);
				alertDailog.Show();
			}
			else {
				
				_locationManager.RequestLocationUpdates(
					LocationManager.NetworkProvider,
						0,   //---time in ms---
						0,   //---distance in metres---
						this);
			}
		}
		~GetMyLocationStatus(){
			_locationManager.RemoveUpdates(this);
		}
	}
	public class LocationEventArgs : EventArgs, MyLocationEventArgs
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}
    }

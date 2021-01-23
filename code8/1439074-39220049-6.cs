    [assembly: Xamarin.Forms.Dependency(typeof(GetILocationStatus))]
    namespace BarberApp.iOS
    {
	public class GetILocationStatus : MyLocationTracker
	{
		public GetILocationStatus() { }
		CLLocationManager lm;
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
	void MyLocationTracker.ObtainMyLocation()
		{
			lm = new CLLocationManager();
			lm.DesiredAccuracy = CLLocation.AccuracyBest;
			lm.DistanceFilter = CLLocationDistance.FilterNone;
			lm.LocationsUpdated +=
				(object sender, CLLocationsUpdatedEventArgs e) =>
				{
					var locations = e.Locations;
					var strLocation =
						locations[locations.Length - 1].
							Coordinate.Latitude.ToString();
					strLocation = strLocation + "," +
						locations[locations.Length - 1].
							Coordinate.Longitude.ToString();
					LocationEventArgs args = new LocationEventArgs();
					args.lat = locations[locations.Length - 1].
						Coordinate.Latitude;
					args.lng = locations[locations.Length - 1].
						Coordinate.Longitude;
					locationObtained(this, args);
				};
			lm.AuthorizationChanged += (object sender,
				CLAuthorizationChangedEventArgs e) =>
			{
				if (e.Status ==
					CLAuthorizationStatus.AuthorizedWhenInUse)
				{
					lm.StartUpdatingLocation();
				}
			};
			lm.RequestWhenInUseAuthorization();
		}
		~GetILocationStatus()
		{
			lm.StopUpdatingLocation();
		}
	}
	public class LocationEventArgs : EventArgs, MyLocationEventArgs
	{
		public double lat { get; set; }
		public double lng { get; set; }
	}
    }

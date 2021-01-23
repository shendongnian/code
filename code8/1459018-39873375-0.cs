    using Windows.Devices.Geolocation;
    ...
    var accessStatus = await Geolocator.RequestAccessAsync();
    switch (accessStatus) {
     case GeolocationAccessStatus.Allowed:
    
      // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
      Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };
    
      // Subscribe to StatusChanged event to get updates of location status changes
      _geolocator.StatusChanged += OnStatusChanged;
    
      try {                        
       // Carry out the operation
       Geoposition pos = await geolocator.GetGeopositionAsync();
      } catch (Exception ex) {
       // handle the exception (notify user, etc.)
      }
      break;
    
     case GeolocationAccessStatus.Denied:
      // handle access denied case here
      break;
    
     case GeolocationAccessStatus.Unspecified:
      // handle unspecified error case here
      break;
    }

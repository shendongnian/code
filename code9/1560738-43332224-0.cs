    Device.BeginInvokeOnMainThread(() =>
    {
      var pin = MyPin();      
        myMap.Pins.Add(pin);
        // This is never called when calling await Dowork(). Application stops.
        myMap.MoveToRegion(MapSpan.FromCenterAndRadius(MyPosition(), Distance.FromMiles(5)));
        success = true;
    });

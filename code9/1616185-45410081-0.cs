    protected override void OnElementChanged (Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
    {
		base.OnElementChanged (e);
		if (e.OldElement != null) {
			NativeMap.InfoWindowClick -= OnInfoWindowClick;
		}
		if (e.NewElement != null) {
			var formsMap = (CustomMap)e.NewElement;
            //register the CollectionChanged event
            formsMap.CustomPins.CollectionChanged += CustomPins_CollectionChanged;
			customPins = formsMap.CustomPins;
			Control.GetMapAsync(this);
		}
	}
    private void CustomPins_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        customPins = (ObservableCollection<CustomPin>)sender;
        //rerender all the pins in the map
        NativeMap.Clear();
        foreach (var pin in customPins)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Pin.Position.Latitude, pin.Pin.Position.Longitude));
            marker.SetTitle(pin.Pin.Label);
            marker.SetSnippet(pin.Pin.Address);
                marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pin));
            NativeMap.AddMarker(marker);
        }
        isDrawn = true;
    }

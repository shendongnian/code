    public void OnMapReady(GoogleMap googleMap)
    {
        _googleMap = googleMap;
    
        if (_googleMap != null)
        {
            _googleMap.MapClick += OnMapClick;
            UpdatePins();
        }
    }
    
    private void UpdatePins(bool firstUpdate = true)
    {
        if (_googleMap == null) return;
    
        if (FormsMap.CustomPins != null)
        {
            foreach (var pin in FormsMap.CustomPins)
            {
                AddPin(pin);
            }
    
            if (firstUpdate)
            {
                var observable = FormsMap.CustomPins as INotifyCollectionChanged;
                if (observable != null)
                {
                    observable.CollectionChanged += OnCustomPinsCollectionChanged;
                }
            }
        }
    }
    
        private void AddPin(CustomPin pin)
        {
            var markerWithIcon = new MarkerOptions();
    
            markerWithIcon.SetPosition(new LatLng(pin.BasePin.Position.Latitude, pin.BasePin.Position.Longitude));
    
            if (!string.IsNullOrWhiteSpace(pin.BasePin.Label))
                markerWithIcon.SetTitle(pin.BasePin.Label);
    
            _googleMap.AddMarker(markerWithIcon);
        }

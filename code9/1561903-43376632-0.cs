        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName.Equals("VisibleRegion") && !_isDrawn)
            {
                PopulateMap();
                OnGoogleMapReady();
            }
        }

    [assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
    namespace Test.iOS.CustomRenderers
    {
        public class CustomMapRenderer : MapRenderer
        {
            private CustomMap FormsMap => Element as CustomMap;
            private MKMapView Map => Control as MKMapView;
    
    
            protected override void OnElementChanged(ElementChangedEventArgs<View> e)
            {
                base.OnElementChanged(e);
    
                if (e.NewElement != null)
                {
                    MoveToCenter();
                }
            }
    
            private void MoveToCenter()
            {
                if (FormsMap != null && FormsMap.MapRegion != null)
                {
                    MoveToMapRegion(FormsMap.MapRegion, false);
                }
            }
    
            public void MoveToMapRegion(MapSpan region, bool animate)
            {
                var locationCoordinate = new CLLocationCoordinate2D(region.Center.Latitude, region.Center.Longitude);
    
                var coordinateRegion = MKCoordinateRegion.FromDistance(
                    locationCoordinate,
                    region.Radius.Meters * 2,
                    region.Radius.Meters * 2);
    
                BeginInvokeOnMainThread(() =>
                {
                    Map.SetRegion(coordinateRegion, animate);
                });
            }
    
      ...
    }

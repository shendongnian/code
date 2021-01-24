    public class MapWithMyZoomControlRenderer : MapRenderer, IOnMapReadyCallback
    {
        private GoogleMap map;
    
        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;
    
            map.UiSettings.ZoomControlsEnabled = false;
        }
    
        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
    
            if (e.OldElement != null)
            {
                // Unsubscribe
            }
    
            if (e.NewElement != null)
            {
                var formsMap = (MapWithMyZoomControl)e.NewElement;
    
                ((MapView)Control).GetMapAsync(this);
            }
        }
    
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var element = Element as MapWithMyZoomControl;
            if (e.PropertyName == "MyZoom" && map != null)
            {
                if (element.MyZoom == MapWithMyZoomControl.ZoomState.zoomin)
                {
                    map.AnimateCamera(CameraUpdateFactory.ZoomIn());
                }
                else if (element.MyZoom == MapWithMyZoomControl.ZoomState.zoomout)
                {
                    map.AnimateCamera(CameraUpdateFactory.ZoomOut());
                }
                element.MyZoom = MapWithMyZoomControl.ZoomState.normal;
            }
        }
    }

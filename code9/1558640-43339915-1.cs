    public class MapWithMyZoomControl : Map
    {
        public ZoomState MyZoom
        {
            get { return (ZoomState)GetValue(MyZoomProperty); }
            set { SetValue(MyZoomProperty, value); }
        }
    
        public static readonly BindableProperty MyZoomProperty =
            BindableProperty.Create(
                propertyName: "MyZoom",
                returnType: typeof(ZoomState),
                declaringType: typeof(MapWithMyZoomControl),
                defaultValue: ZoomState.normal,
                propertyChanged: OnZoomPropertyChanged);
    
        public static void OnZoomPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
    
        public enum ZoomState
        {
            normal,
            zoomin,
            zoomout
        }
    }

    public class MyWebView : WebView
    {
        public int ZoomInLevel
        {
            get { return (int)GetValue(ZoomInLevelProperty); }
            set { SetValue(ZoomInLevelProperty, value); }
        }
    
        public static readonly BindableProperty ZoomInLevelProperty =
            BindableProperty.Create(
                propertyName: "ZoomInLevel",
                returnType: typeof(int),
                declaringType: typeof(MyWebView),
                defaultValue: 3,
                propertyChanged: OnZoomLevelPropertyChanged);
    
        public int ZoomOutLevel
        {
            get { return (int)GetValue(ZoomOutLevelProperty); }
            set { SetValue(ZoomOutLevelProperty, value); }
        }
    
        public static readonly BindableProperty ZoomOutLevelProperty =
            BindableProperty.Create(
                propertyName: "ZoomOutLevel",
                returnType: typeof(int),
                declaringType: typeof(MyWebView),
                defaultValue: 3,
                propertyChanged: OnZoomLevelPropertyChanged);
    
        private static void OnZoomLevelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
    }

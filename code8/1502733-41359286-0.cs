    public class MyWebView:WebView
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
                declaringType:typeof(MyWebView),
                defaultValue:3,
                propertyChanged: OnZoomInLevelPropertyChanged);
    
        private static void OnZoomInLevelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {           
        }
    
    }

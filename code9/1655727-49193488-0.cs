    [assembly: ExportRenderer(typeof(Button), typeof(MyButtonRenderer))]
    namespace CarPool.Forms.Droid.Renderers
    {
        public class MyButtonRenderer : ButtonRenderer
        {
            public MyButtonRenderer(Context context) : base(context) { }
    
            protected override void OnElementChanged(ElementChangedEventArgs<Button> args)
            {
                base.OnElementChanged(args);
                if (Control != null) SetColors();
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
            {
                base.OnElementPropertyChanged(sender, args);
                if (args.PropertyName == nameof(Button.IsEnabled)) SetColors();
            }
    
            private void SetColors()
            {
                Control.SetTextColor(Element.IsEnabled ? Element.TextColor.ToAndroid() : Android.Graphics.Color.Gray);
                Control.SetBackgroundColor(Element.IsEnabled ? Element.BackgroundColor.ToAndroid() : Android.Graphics.Color.DarkGray);
            }
        }
    }

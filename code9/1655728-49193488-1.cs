    [assembly: ExportRenderer(typeof(Button), typeof(MyButtonRenderer))]
    namespace CarPool.Forms.iOS.Renderers
    {
        public class MyButtonRenderer : ButtonRenderer
        {
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
                Control.SetTitleColor(Element.IsEnabled ? Element.TextColor.ToUIColor() : UIColor.Gray, Element.IsEnabled ? UIControlState.Normal : UIControlState.Disabled);
                Control.BackgroundColor = Element.IsEnabled ? Element.BackgroundColor.ToUIColor() : UIColor.DarkGray;
            }
        }
    }

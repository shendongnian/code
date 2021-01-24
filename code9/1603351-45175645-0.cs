    [assembly: ExportRenderer(typeof(GradientStack), typeof(GradientStackRenderer))]
    
    namespace yournamespace.iOS
    {
        class GradientStackRenderer : ViewRenderer<StackLayout, UIView>
        {
            
            public override void Draw(CGRect rect)
            {
                base.Draw(rect);
                CAGradientLayer layer = new CAGradientLayer();
                layer.Frame = rect;
                layer.Colors = new CGColor[]
                {
                    ((GradientStack)Element).StartColor.ToCGColor(),
                    ((GradientStack)Element).EndColor.ToCGColor()
                };
    
                if(Layer.Sublayers[0] is CAGradientLayer)
                    Layer.ReplaceSublayer(Layer.Sublayers[0], layer);
                else
                    Layer.InsertSublayer(layer, 0);
    
            }
    
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
    
                if(e.PropertyName=="Width")
                    SetNeedsDisplay();
            }
    
           
        }
    }

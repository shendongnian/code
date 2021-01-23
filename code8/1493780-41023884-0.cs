    public static class Attached
    {
        public static readonly DependencyProperty CornerRadiusProperty
                = DependencyProperty.RegisterAttached("CornerRadius",
                        typeof(CornerRadius), typeof(Attached),
                        new FrameworkPropertyMetadata(
                            new CornerRadius(0), 
                            FrameworkPropertyMetadataOptions.AffectsRender 
                                | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                            PropertyChanged)
                        );
    
        public static CornerRadius GetCornerRadius(DependencyObject uie)
        {
            return (CornerRadius)uie.GetValue(CornerRadiusProperty);
        }
    
        public static void SetCornerRadius(DependencyObject uie, CornerRadius value)
        {
            uie.SetValue(CornerRadiusProperty, value);
        }
    }

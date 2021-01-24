    public static class RCT
    {
        public static readonly DependencyProperty RemapColorProperty =
            DependencyProperty.RegisterAttached(
                "RemapColor", typeof(RemapColors), typeof(RCT),
                new FrameworkPropertyMetadata(RemapColors.SeaGreen,
                    FrameworkPropertyMetadataOptions.Inherits |
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public static RemapColors GetRemapColor(DependencyObject obj)
        {
            return (RemapColors)obj.GetValue(RemapColorProperty);
        }
        public static void SetRemapColor(DependencyObject obj, RemapColors value)
        {
            obj.SetValue(RemapColorProperty, value);
        }
    }
    public class RCTButton : Button
    {
        public static readonly DependencyProperty RemapColorProperty =
            RCT.RemapColorProperty.AddOwner(
                typeof(RCTButton), new FrameworkPropertyMetadata(OnVisualChanged));
        public RemapColors RemapColor
        {
            get { return (RemapColors)GetValue(RemapColorProperty); }
            set { SetValue(RemapColorProperty, value); }
        }
        private static void OnVisualChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("RCTButton.OnVisualChanged");
        }
    }
    public class RCTWindow : ContentControl
    {
        public static readonly DependencyProperty RemapColorProperty =
            RCT.RemapColorProperty.AddOwner(
                typeof(RCTWindow), new FrameworkPropertyMetadata(OnVisualChanged));
        public RemapColors RemapColor
        {
            get { return (RemapColors)GetValue(RemapColorProperty); }
            set { SetValue(RemapColorProperty, value); }
        }
        private static void OnVisualChanged(
            DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("RCTWindow.OnVisualChanged");
        }
    }

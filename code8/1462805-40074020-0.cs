    public class CompatExtensions
    {
        public static bool GetAllowFocusOnInteraction(DependencyObject obj)
        {
            return (bool)obj.GetValue(AllowFocusOnInteractionProperty);
        }
        public static void SetAllowFocusOnInteraction(DependencyObject obj, bool value)
        {
            obj.SetValue(AllowFocusOnInteractionProperty, value);
        }
        // Using a DependencyProperty as the backing store for AllowFocusOnInteraction.  
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowFocusOnInteractionProperty =
            DependencyProperty.RegisterAttached("AllowFocusOnInteraction", 
                                                typeof(bool),
                                                typeof(CompatExtensions),
                                                new PropertyMetadata(0, AllowFocusOnInteractionChanged));
    
        private static bool allowFocusOnInteractionAvailable = 
            Windows.Foundation.Metadata.ApiInformation.IsPropertyPresent(
                "Windows.UI.Xaml.FrameworkElement", 
                "AllowFocusOnInteraction");
        private static void AllowFocusOnInteractionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (allowFocusOnInteractionAvailable)
            {
                var element = d as FrameworkElement;
                if (element != null)
                {
                    element.AllowFocusOnInteraction = (bool)e.NewValue;
                }
            }
        }
    }

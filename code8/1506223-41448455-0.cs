    public class FocusHighlightBehavior : Behavior<Path>
    {
        public FrameworkElement FocusElement
        {
            get { return (FrameworkElement)GetValue(FocusElementProperty); }
            set { SetValue(FocusElementProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FocusElement.
        public static readonly DependencyProperty FocusElementProperty =
            DependencyProperty.Register("FocusElement", typeof(FrameworkElement), typeof(FocusHighlightBehavior), new PropertyMetadata(null, (o,e) =>
            {
                //this is the property changed event for the dependency property!
                (o as FocusHighlightBehavior).UpdateFocusElement();
            }));
        private void UpdateFocusElement()
        {
            if (FocusElement != null)
            {
                FocusElement.GotFocus += FocusElement_GotFocus;
                FocusElement.LostFocus += FocusElement_LostFocus;
            }
        }
        private void FocusElement_LostFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Fill = Brushes.Gray;
        }
        private void FocusElement_GotFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Fill = Brushes.Orange;
        }
    }

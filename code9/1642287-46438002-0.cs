    public static class ScrollViewerAttachedProperties
    {
        public static readonly DependencyProperty ScrollToBottomOnChangeProperty = DependencyProperty.RegisterAttached(
            "ScrollToBottomOnChange", typeof(object), typeof(ScrollViewerAttachedProperties), new PropertyMetadata(default(ScrollViewer), OnScrollToBottomOnChangeChanged));
    
        private static void OnScrollToBottomOnChangeChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var scrollViewer = dependencyObject as ScrollViewer;
            scrollViewer?.ScrollToBottom();
        }
    
        public static void SetScrollToBottomOnChange(DependencyObject element, object value)
        {
            element.SetValue(ScrollToBottomOnChangeProperty, value);
        }
    
        public static object GetScrollToBottomOnChange(DependencyObject element)
        {
            return element.GetValue(ScrollToBottomOnChangeProperty);
        }
    }

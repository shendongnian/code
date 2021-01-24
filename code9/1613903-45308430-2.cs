    static class ScrollableWrapPanel
    {
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(ScrollableWrapPanel), new PropertyMetadata(false, IsEnabledChanged));
        // DP Get/Set static methods omitted
        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var panel = (WrapPanel)d;
            if (!panel.IsInitialized)
            {
                panel.Initialized += PanelInitialized;        
            }
            // Add here the IsEnabled == false logic, if you wish
        }
        static void PanelInitialized(object sender, EventArgs e)
        {
            var panel = (WrapPanel)sender;
            // Monitor the Orientation property.
            // There is no OrientationChanged event, so we use the DP tools.
            DependencyPropertyDescriptor.FromProperty(
                WrapPanel.OrientationProperty,
                typeof(WrapPanel))
            .AddValueChanged(panel, OrientationChanged);
            panel.Unloaded += PanelUnloaded;
            // Sets up our custom behavior for the first time
            OrientationChanged(panel, EventArgs.Empty);
        }
        static void OrientationChanged(object sender, EventArgs e)
        {
            var panel = (WrapPanel)sender;
            if (panel.Orientation == Orientation.Vertical)
            {
                // We might have set it for the Horizontal orientation
                BindingOperations.ClearBinding(panel, WrapPanel.MinWidthProperty);
                // This multi-binding monitors the heights of the children
                // and returns the maximum height.
                var converter = new MaxValueConverter();
                var minHeightBiding = new MultiBinding { Converter = converter };
                foreach (var child in panel.Children.OfType<FrameworkElement>())
                {
                    minHeightBiding.Bindings.Add(new Binding("ActualHeight") { Mode = BindingMode.OneWay, Source = child });
                }
  
                BindingOperations.SetBinding(panel, WrapPanel.MinHeightProperty, minHeightBiding);
                // We might have set it for the Horizontal orientation        
                BindingOperations.ClearBinding(panel, WrapPanel.WidthProperty);
                // We have to define the wrap panel's height for the vertical orientation
                var binding = new Binding("ViewportHeight")
                {
                    RelativeSource = new RelativeSource { Mode = RelativeSourceMode.FindAncestor, AncestorType = typeof(ScrollViewer)}
                };
                BindingOperations.SetBinding(panel, WrapPanel.HeightProperty, binding);
            }
            else
            {
                // The "transposed" case for the horizontal wrap panel
            }
        }
        static void PanelUnloaded(object sender, RoutedEventArgs e)
        {
            var panel = (WrapPanel)sender;
            panel.Unloaded -= PanelUnloaded;
            // This is really important to prevent the memory leaks.
            DependencyPropertyDescriptor.FromProperty(WrapPanel.OrientationProperty, typeof(WrapPanel))
                .RemoveValueChanged(panel, OrientationChanged);
        }
        private class MaxValueConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                return values.Cast<double>().Max();
            }
            // ConvertBack omitted
        }
    }

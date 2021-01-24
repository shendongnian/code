    /// <summary>
    /// Helper for allowing scroll events to pass from a <see cref="DataGrid"/> to its parent.
    /// This ensures that a "scroll down" event occurring at an already scrolled-down
    /// <see cref="DataGrid"/> will be passed on to its parent, which might be able to handle
    /// it instead.
    /// </summary>
    public class DataGridScrollCorrector
    {
        public static bool GetFixScrolling(DependencyObject obj) =>
            (bool)obj.GetValue(FixScrollingProperty);
        public static void SetFixScrolling(DependencyObject obj, bool value) =>
            obj.SetValue(FixScrollingProperty, value);
        public static readonly DependencyProperty FixScrollingProperty =
            DependencyProperty.RegisterAttached("FixScrolling", typeof(bool), typeof(DataGridScrollCorrector), new FrameworkPropertyMetadata(false, OnFixScrollingPropertyChanged));
        private static void OnFixScrollingPropertyChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var grid = sender as DataGrid;
            if (grid == null)
                throw new ArgumentException("The dependency property can only be attached to a DataGrid", nameof(sender));
            if ((bool)e.NewValue)
                grid.PreviewMouseWheel += HandlePreviewMouseWheel;
            else
                grid.PreviewMouseWheel -= HandlePreviewMouseWheel;
        }
        /// <summary>
        /// Finds the first child of a given type in a given <see cref="DependencyObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of the child to search for.</typeparam>
        /// <param name="depObj">The object whose children we are interested in.</param>
        /// <returns>The child object.</returns>
        private static T FindVisualChild<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                var visualChild = child as T;
                if (visualChild != null) return visualChild;
                var childItem = FindVisualChild<T>(child);
                if (childItem != null) return childItem;
            }
            return null;
        }
        /// <summary>
        /// Attempts to scroll the <see cref="ScrollViewer"/> in the <see cref="DataGrid"/>.
        /// If no scrolling occurs, pass the event to a parent.
        /// </summary>
        private static void HandlePreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var grid = sender as DataGrid;
            var viewer = FindVisualChild<ScrollViewer>(grid);
            if (viewer != null)
            {
                // We listen on changes to the ScrollViewer's scroll offset; if that changes
                // we can consider our event handled. In case the ScrollChanged event is never
                // raised, we take this to mean that we are at the top/bottom of our scroll viewer,
                // in which case we provide the event to our parent.
                ScrollChangedEventHandler handler = (senderScroll, eScroll) =>
                    e.Handled = true;
                viewer.ScrollChanged += handler;
                // Scroll +/- 3 rows depending on whether we are scrolling up or down. The
                // forced layout update is necessary to ensure that the event is called
                // immediately (as opposed to after some small delay).
                double oldOffset = viewer.VerticalOffset;
                double offsetDelta = e.Delta > 0 ? -3 : 3;
                viewer.ScrollToVerticalOffset(oldOffset + offsetDelta);
                viewer.UpdateLayout();
                viewer.ScrollChanged -= handler;
            }
            if (e.Handled) return;
            e.Handled = true;
            var eventArg =
                new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
                {
                    RoutedEvent = UIElement.MouseWheelEvent,
                    Source = sender
                };
            var parent = ((Control)sender).Parent as UIElement;
            parent?.RaiseEvent(eventArg);
        }
    }

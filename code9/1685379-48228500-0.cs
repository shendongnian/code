    public class EnterKeyTraversal
    {
        public static bool GetIsEnabled(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsEnabledProperty);
        }
        public static void SetIsEnabled(DependencyObject obj, bool value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }
        static void ue_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var ue = e.OriginalSource as FrameworkElement;
            var parent = GetVisualParent<DataGrid>(ue);
            if (parent == null) return;
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ue.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
                parent.SelectedIndex += 1;
            }
        }
        private static void ue_Unloaded(object sender, RoutedEventArgs e)
        {
            var ue = sender as FrameworkElement;
            if (ue == null) return;
            ue.Unloaded -= ue_Unloaded;
            ue.PreviewKeyDown -= ue_PreviewKeyDown;
        }
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(bool),
            typeof(EnterKeyTraversal), new UIPropertyMetadata(false, IsEnabledChanged));
        static void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ue = d as FrameworkElement;
            if (ue == null) return;
            if ((bool)e.NewValue)
            {
                ue.Unloaded += ue_Unloaded;
                ue.PreviewKeyDown += ue_PreviewKeyDown;
            }
            else
            {
                ue.PreviewKeyDown -= ue_PreviewKeyDown;
            }
        }
        public static T GetVisualParent<T>(DependencyObject child) where T : Visual
        {
            Visual parentObject = VisualTreeHelper.GetParent(child) as Visual;
            if (parentObject == null) return null;
            return parentObject is T ? parentObject as T : GetVisualParent<T>(parentObject);
        }
    }

    public static class TreeViewAttached
    {
        #region TreeViewAttached.SelectedItem Attached Property
        public static Object GetSelectedItem(TreeView obj)
        {
            return (Object)obj.GetValue(SelectedItemProperty);
        }
        public static void SetSelectedItem(TreeView obj, Object value)
        {
            obj.SetValue(SelectedItemProperty, value);
        }
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.RegisterAttached("SelectedItem", typeof(Object), typeof(TreeViewAttached),
                new FrameworkPropertyMetadata(null) {
                    BindsTwoWayByDefault = true
                });
        #endregion TreeViewAttached.SelectedItem Attached Property
        #region TreeViewAttached.MonitorSelectedItem Attached Property
        public static bool GetMonitorSelectedItem(TreeView obj)
        {
            return (bool)obj.GetValue(MonitorSelectedItemProperty);
        }
        public static void SetMonitorSelectedItem(TreeView obj, bool value)
        {
            obj.SetValue(MonitorSelectedItemProperty, value);
        }
        public static readonly DependencyProperty MonitorSelectedItemProperty =
            DependencyProperty.RegisterAttached("MonitorSelectedItem", typeof(bool), typeof(TreeViewAttached),
                new PropertyMetadata(false, MonitorSelectedItem_PropertyChanged));
        private static void MonitorSelectedItem_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                (d as TreeView).SelectedItemChanged += TreeViewAttached_SelectedItemChanged;
            }
            else
            {
                (d as TreeView).SelectedItemChanged -= TreeViewAttached_SelectedItemChanged;
            }
        }
        private static void TreeViewAttached_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            SetSelectedItem(sender as TreeView, e.NewValue);
        }
        #endregion TreeViewAttached.MonitorSelectedItem Attached Property
    }

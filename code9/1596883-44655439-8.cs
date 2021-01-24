    public static class ListBoxExtensions
    {
        #region ListBoxExtensions.KeepSelectedItemVisible Attached Property
        public static bool GetKeepSelectedItemVisible(ListBox lb)
        {
            return (bool)lb.GetValue(KeepSelectedItemVisibleProperty);
        }
        public static void SetKeepSelectedItemVisible(ListBox lb, bool value)
        {
            lb.SetValue(KeepSelectedItemVisibleProperty, value);
        }
        public static readonly DependencyProperty KeepSelectedItemVisibleProperty =
            DependencyProperty.RegisterAttached("KeepSelectedItemVisible", typeof(bool), typeof(ListBoxExtensions),
                new PropertyMetadata(false, KeepSelectedItemVisible_PropertyChanged));
        private static void KeepSelectedItemVisible_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var lb = (ListBox)d;
            if ((bool)e.NewValue)
            {
                lb.SelectionChanged += ListBox_SelectionChanged;
                ScrollSelectedItemIntoView(lb);
            }
            else
            {
                lb.SelectionChanged -= ListBox_SelectionChanged;
            }
        }
        private static void ScrollSelectedItemIntoView(ListBox lb)
        {
            lb.ScrollIntoView(lb.SelectedItem);
        }
        private static void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollSelectedItemIntoView((ListBox)sender);
        }
        #endregion ListBoxExtensions.KeepSelectedItemVisible Attached Property
    }

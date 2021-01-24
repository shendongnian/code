    public static class GridViewExt
    {
        #region GridViewExt.SortColumnPath Attached Property
        public static String GetSortColumnPath(GridViewColumn obj)
        {
            return (String)obj.GetValue(SortColumnPathProperty);
        }
        public static void SetSortColumnPath(GridViewColumn obj, String value)
        {
            obj.SetValue(SortColumnPathProperty, value);
        }
        public static readonly DependencyProperty SortColumnPathProperty =
            DependencyProperty.RegisterAttached("SortColumnPath", typeof(String), typeof(GridViewExt),
                new PropertyMetadata(null, SortColumnPath_PropertyChanged));
        private static void SortColumnPath_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as GridViewColumn;
        }
        #endregion GridViewExt.SortColumnPath Attached Property
    }

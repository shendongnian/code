    public class TreeviewSelectedItemTracker
    {
        public static TreeTablesViewModel GetSelectedItemHolder(DependencyObject obj)
        {
            return (TreeTablesViewModel)obj.GetValue(SelectedItemHolderProperty);
        }
        public static void SetSelectedItemHolder(DependencyObject obj, TreeTablesViewModel value)
        {
            obj.SetValue(SelectedItemHolderProperty, value);
        }
        public static readonly DependencyProperty SelectedItemHolderProperty =
            DependencyProperty.RegisterAttached("SelectedItemHolder", typeof(TreeTablesViewModel), typeof(TreeviewSelectedItemTracker), new PropertyMetadata(null, OnSelectedChanged));
        private static void OnSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TreeView tv = (TreeView)d;
            tv.Loaded += Tv_Loaded;
        }
        private static void Tv_Loaded(object sender, RoutedEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            tv.Loaded -= Tv_Loaded;
            tv.Unloaded += Tv_Unloaded;
            tv.SelectedItemChanged += Tv_SelectedItemChanged;
        }
        private static void Tv_Unloaded(object sender, RoutedEventArgs e)
        {
            TreeView tv = (TreeView)sender;
            tv.Unloaded -= Tv_Unloaded;
            tv.SelectedItemChanged -= Tv_SelectedItemChanged;
        }
        private static void Tv_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView tv = (TreeView)sender;
            
            var cotr = GetSelectedItemHolder(tv);
            cotr.SelectedItem = tv.SelectedItem;
            
        }
    }

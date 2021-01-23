    public class ViewHelpers
    {
        #region ItemClickCommand
        public static readonly DependencyProperty ItemClickCommandProperty =
            DependencyProperty.RegisterAttached("ItemClickCommand", typeof(ICommand), typeof(ViewHelpers), new PropertyMetadata(null, onItemClickCommandPropertyChanged));
        public static void SetItemClickCommand(DependencyObject d, ICommand value)
        {
            d.SetValue(ItemClickCommandProperty, value);
        }
        public static ICommand GetItemClickCommand(DependencyObject d)
        {
            return (ICommand)d.GetValue(ItemClickCommandProperty);
        }
        static void onItemClickCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = d as ListViewBase;
            if (listView == null)
                throw new Exception("Dependency object must be a ListViewBase");
            listView.ItemClick -= onItemClick;
            listView.ItemClick += onItemClick;
        }
        static void onItemClick(object sender, ItemClickEventArgs e)
        {
            var listView = sender as ListViewBase;
            var command = GetItemClickCommand(listView);
            if (command != null && command.CanExecute(e.ClickedItem))
                command.Execute(e.ClickedItem);
        }
        #endregion
    }

    public static class ListViewItemBehavior
        {
            public static readonly DependencyProperty AutoScrollToCurrentItemProperty =
                DependencyProperty.RegisterAttached("AutoScrollToSelectedItem",
                    typeof(bool), typeof(ListViewItemBehavior),
                    new UIPropertyMetadata(default(bool), OnAutoScrollToCurrentItemChanged));
    
            public static bool GetAutoScrollToCurrentItem(DependencyObject obj)
            {
                return (bool)obj.GetValue(AutoScrollToCurrentItemProperty);
            }
    
            public static void OnAutoScrollToCurrentItemChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                var listView = obj as ListBox;
                if (listView == null) return;
    
                var newValue = (bool)e.NewValue;
                if (newValue)
                    listView.SelectionChanged += listviewSelectionChanged;
                else
                    listView.SelectionChanged -= listviewSelectionChanged;
            }
    
            static void listviewSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var listview = sender as ListView;
                if (listview == null || listview.SelectedItem == null || listview.Items == null) return;
    
                listview.Items.MoveCurrentTo(listview.SelectedItem);
                listview.ScrollIntoView(listview.SelectedItem);
            }
    
            public static void SetAutoScrollToCurrentItem(DependencyObject obj, bool value)
            {
                obj.SetValue(AutoScrollToCurrentItemProperty, value);
            }
        }

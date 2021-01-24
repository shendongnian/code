    private void CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new System.Action(delegate ()
        {
            if (LView != null && LView.Items.Count > 0)
            {
                LView.UpdateLayout();
                ScrollViewer sv = GetChildOfType<ScrollViewer>(LView);
                if (sv != null)
                    sv.ScrollToBottom();
                LView.SelectedIndex = LView.Items.Count;
                LView.ScrollIntoView(LView.SelectedItem);
            }
        }));
    }
    private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null)
            return null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            var result = (child as T) ?? GetChildOfType<T>(child);
            if (result != null)
                return result;
        }
        return null;
    }

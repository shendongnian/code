    private void SymbolGridView_RightTapped(object sender, RightTappedRoutedEventArgs e)
    {
        ListViewItemPresenter lvi = e.OriginalSource as ListViewItemPresenter;
        if (lvi == null)
            lvi = FindParent<ListViewItemPresenter>(e.OriginalSource as DependencyObject);
        if (lvi != null)
        {
            SymbolItem clickedItem = lvi.DataContext as SymbolItem;
            if (clickedItem != null)
                MyMediaElement.Source = new Uri(this.BaseUri, symbolItem.ExampleAudio);
        }
    }
    private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
    {
        var parent = VisualTreeHelper.GetParent(dependencyObject);
        if (parent == null) return null;
        var parentT = parent as T;
        return parentT ?? FindParent<T>(parent);
    }

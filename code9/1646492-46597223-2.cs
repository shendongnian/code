    private void FilterListView(object sender, TextChangedEventArgs e)
    {
        if (this.ProjectListView != null)
        {
            CollectionViewSource.GetDefaultView(this.ProjectListView.ItemsSource).Refresh();
        }
    }

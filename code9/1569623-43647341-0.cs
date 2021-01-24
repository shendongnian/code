    private void OnWindowLoaded(object sender, RoutedEventArgs e)
    {
        var dataContext = DataContext as IViewModel;
        if (dataContext != null)
        {
            dataContext.CommitEdit += (()=>{ Container.View.RadGrid.CommitEdit(); })
        }
    }

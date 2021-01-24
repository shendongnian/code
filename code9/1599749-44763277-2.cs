    public void Execute(object parameter)
    {
        Documents.First().LinkedEmployees.First().Status = !Documents.First().LinkedEmployees.First().Status;
        ICollectionView view = CollectionViewSource.GetDefaultView(Documents);
        view.Filter = (item) => item != null;
        MainGrid.ItemsSource = view;
        MainGrid.UpdateLayout();
        List<DataGrid> childGrids = new List<DataGrid>();
        foreach (var item in MainGrid.Items)
        {
            var container = MainGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
            if (container != null)
            {
                childGrids.AddRange(FindVisualChildren<DataGrid>(container));
            }
        }
    }

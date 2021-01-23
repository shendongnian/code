    System.Windows.Data.CollectionViewSource locationViewSource =
               ((System.Windows.Data.CollectionViewSource)(this.FindResource("locationsVwSrc")));
    // locationViewSource.Source = viewModel.Locations;
    Binding b = new Binding("Locations");
    b.Source = viewModel;
    b.Mode = BindingMode.OneWay;
    BindingOperations.SetBinding(locationViewSource, CollectionViewSource.SourceProperty, b);

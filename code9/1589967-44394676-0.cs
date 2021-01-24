    // DevicesGrid is the DataGrid with the data I want to filter
    // this next line gets the textbox contents to filter on, you won't need this
    Controls.TextBox textbox = sender as Controls.TextBox;
            ICollectionView cvs = CollectionViewSource.GetDefaultView(DevicesGrid.ItemsSource);
       // doing the filter
    // A PortResult is what is in the collection, replace that with whatever is in yours
            cvs.Filter = new Predicate<object>(item =>
            {
                PortResult pr = item as PortResult;
                if (pr.Name.Contains(textbox.Text))
                { return true; }
                else { return false; }
            });

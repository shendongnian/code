    var sorting = DataGrid.Items.SortDescriptions
           .Select(x => new {x.PropertyName, x.Direction}).ToList();
    DataGrid.ItemsSource = myListCollectionView;
                    
    foreach (var item in sorting)
    {
       var col = DataGrid.Columns
                   .First(x => x.SortMemberPath == item.PropertyName);
       col.SortDirection = item.Direction;
       DataGrid.Items.SortDescriptions.Add(
             new SortDescription(item.PropertyName, item.Direction));
     };

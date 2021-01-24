    //Create a ListCollectionView of your List of new agents
    ListCollectionView myListCollectionView = new ListCollectionView(newAgents);
    //Sort your collection view
    myListCollectionView .SortDescriptions.Add(new SortDescription("AgentState", ListSortDirection.Ascending));
    myListCollectionView .SortDescriptions.Add(new SortDescription("AuxReasons", ListSortDirection.Descending));
    myListCollectionView .SortDescriptions.Add(new SortDescription("AgentDateTimeStateChange", ListSortDirection.Descending));
    //Bind your data
    DataGrid.ItemsSource = myCollectionView;

     CollectionViewSource collectionViewSource = new CollectionViewSource();
            collectionViewSource.Source = new List<RowItem>()
                {
                  new RowItem() {NumberOfOrder =1, Name ="kong foo" },
                  new RowItem() {NumberOfOrder =1,Name ="asdf" },
                  new RowItem() {NumberOfOrder =2,Name ="asdf" },
                  new RowItem() {NumberOfOrder =3,Name ="foo"}
                };
    
    
            collectionViewSource.GroupDescriptions.Add(new PropertyGroupDescription("NumberOfOrder"));
    
            DataContext = collectionViewSource;

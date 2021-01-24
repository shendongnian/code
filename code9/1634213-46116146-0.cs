    private void Dg_Loaded(object sender, RoutedEventArgs e)
    {
        CreateList(typeof(CreditorClient));
    }    
    async private void CreateList(Type DataModel)
    {
        Type genericType = typeof(ObservableCollection<>).MakeGenericType(DataModel);
        CreditorList = new ObservableCollection<Activator.CreateInstance(genericType)>();
    }

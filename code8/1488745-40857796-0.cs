    public ItemsViewModel()
    {
        Items = new ObservableCollection<Item>();
        _isBusy = false;
    
        Task.Run(async () => await LoadItems());    
    }
    public async Task LoadItems()
    {
        var items = new ObservableCollection<Item>(); // new collection
        if (!IsBusy)
        {
            IsBusy = true;
            await Task.Delay(3000); 
            var loadedItems = ItemsService.LoadItemsDirectory(); 
    
            foreach (var item in loadedItems)
                items.Add(item);                // items are added to the new collection    
        
            Items = items;   // swap the collection for the new one
            RaisePropertyChanged(nameof(Items)); // raise a property change in whatever way is right for your VM
            IsBusy = false;
        }
    }

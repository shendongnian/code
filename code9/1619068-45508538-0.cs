    private Lazy<RelayCommand> _loadItemsCommand = new Lazy<RelayCommand>(() =>
        new RelayCommand(async () => await SetItems())
    );
    public RelayCommand LoadItemsCommand 
        get {
            return _loadItemsCommand.Value;
        }
    }
    public async Task SetItems() {
        try {
            IsBusy = true; // On UI Thread
            var getItems = await service.GetItems(); //asynchronous task on a background thread
    
            //Back on the UI Thread
            //SETTING LISTS
    
            selectedItem = null;
            searchString = string.Empty;
    
            IsBusy = false; // On UI Thread
        } catch (Exception a) {
            //log it
            IsBusy = false;
        }
    }

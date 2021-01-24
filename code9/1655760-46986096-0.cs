    private async Task InitLocalStoreAsync()
    {
       if (!App.MobileService.SyncContext.IsInitialized)
       {
           var store = new MobileServiceSQLiteStore("localstore.db");
           store.DefineTable<TodoItem>();
           await App.MobileService.SyncContext.InitializeAsync(store);
       }
       await SyncAsync();
    }
    private async Task SyncAsync()
    {
       await App.MobileService.SyncContext.PushAsync();
       await todoTable.PullAsync("todoItems", todoTable.CreateQuery());
    }

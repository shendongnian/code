    protected override async void OnAppearing()
    {
        base.OnAppearing();
    
        TodoItem item = new TodoItem { Text = "Awesome item" };
        await MobileService.GetSyncTable<TodoItem>().InsertAsync(item);
    
        List<ToDoItem> allItems = await MobileService.GetSyncTable<TodoItem>().ToEnumerableAsync();
    }

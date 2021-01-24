    public async Task<ObservableCollection<TodoItem>> GetTodoItemsAsync (bool syncItems = false)
    {
      ...
      IEnumerable<TodoItem> items = await todoTable
                  .Where (todoItem => !todoItem.Done)
                  .ToEnumerableAsync ();
    
      return new ObservableCollection<TodoItem> (items);
    }

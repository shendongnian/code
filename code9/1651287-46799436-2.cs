    public async Task<TodoItem> GetTodoItemAsync(string name)
    {
        try
        {
            TodoItem item = await todoTable
                .Where(todoItem => todoItem.Name.Equals(name))
                .Select(todoItem => todoItem)
                .ToListAsync()
                .FirstOrDefault();
    
            return item;
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"Exception: {0}", e.Message);
        }
        return null;
    }

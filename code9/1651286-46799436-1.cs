    public async Task<TodoItem> GetTodoItemAsync(string name)
    {
        try
        {
            TodoItem item = await todoTable
                .Where(todoItem => todoItem.Name.Equals(name))
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

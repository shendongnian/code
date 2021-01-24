    public async Task<TodoItem> GetTodoItemAsync(string name)
    {
        try
        {
            TodoItem item = await todoTable
                .Select(todoItem => todoItem.Name.Equals(name))
                .FirstOrDefault();
    
            return item;
        }
        catch (Exception e)
        {
            Debug.WriteLine(@"Exception: {0}", e.Message);
        }
        return null;
    }

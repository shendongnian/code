    // GET tables/TodoItem
    [ExpandProperty("Tags")]
    public IQueryable<TodoItem> GetAllTodoItems()
    {
        return Query();
    }

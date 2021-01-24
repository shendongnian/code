    [Singleton("ItemsLock", SingletonScope.Host)]
    public static void AddItem([QueueTrigger("add-item")] string message)
    {
         // Perform the add operation
    }
    
    [Singleton("ItemsLock", SingletonScope.Host)]
    public static void RemoveItem([QueueTrigger("remove-item")] string message)
    {
         // Perform the remove operation
    }

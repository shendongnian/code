    using (EntityConnection efConnection = new EntityConnection("[EF_connection_string]"))
    {
    
        // DataContext is your data context class name inherited from DbContext
        DataContext dataContext = new DataContext(efConnection);
    }

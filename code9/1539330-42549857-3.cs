    public void DetachAndResetKeys(Car entity)
    {
        // Load references if needed
    
        // Detach
        _dbContext.Detach( entity );
        // Reset Key. 0 equals not set for int key
        entity.Id = 0;
        
        entity.CarType = null;
    }

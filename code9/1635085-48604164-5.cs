    public async Task MyMethod()
    {
        await _repository.InsertAndGetIdAsync(new Test
        {
            Code = "One",
            MyUniqueId = 1
        });
    
        // Valid
        await _repository.InsertAndGetIdAsync(new Test
        {
            Code = "Two",
            MyUniqueId = 2
        });
    
        try
        {
            await _repository.InsertAndGetIdAsync(new Test
            {
                Code = "One", // PK conflict
                MyUniqueId = 3
            });
        }
        catch (Exception e)
        {
        }
    
        try
        {
            await _repository.InsertAndGetIdAsync(new Test
            {
                Code = "Three",
                MyUniqueId = 1 // Unique constraint conflict
            });
        }
        catch (Exception e)
        {
            throw;
        }
    
        return null;
    }

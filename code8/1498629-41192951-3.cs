    public void UpdateBackingAcc()
    {
        try
        {
            // Hypotetically:
            // assuming service throws InvalidOperationException when personId is invalid 
            Amount = _service.GetAccDetails(_personId);
        }
        catch (InvalidOperationException ioex)
        {
            // e.g. some logger logs this exception
            throw;
        }
    }

    public void AddApplePie(string incredientA, string incredientB)
    {
        try
        {
            ...
        }
        catch(Exception ex)
        {
            throw new PieRepositoryException("Error adding apple pie.", ex, incredientA, incredientB); 
        }
    }

    public bool TryCreate<T>(YourType row, out T result) where T : class
    {
        try
        {
            //set result to a properly initialized object
            return true;
        }
        catch(Exception e)
        {
            result = null;
            return false;
        }
    }

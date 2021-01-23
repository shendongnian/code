    public bool Add(T entity, Expression<Func<T, bool>> filter = null)
    {
        try
        {
            genericRepository.Add(entity, filter);
        }
        catch (Exception e)
        {
           return false;
        }
        return true;
    }

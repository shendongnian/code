    public bool Add(T entity, Expression<Func<T, bool>> filter = null)
    {
        try
        {
            genericRepository.Add(entity, filter).Wait();
        }
        catch (Exception e)
        {
           return false;
        }
        return true;
    }

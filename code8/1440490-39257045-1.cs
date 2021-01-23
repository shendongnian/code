    public TResult ActionWithTryCatch<TResult>(Func<TResult> del, string viewName)
    {
        try
        {
            return del.Invoke();
        }
        catch (Exception e)
        {
            LogException(e.Message);
            AddModelError(e.Message);
            throw;
        }
    }

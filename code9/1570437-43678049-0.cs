    public void Delete(T post)
        where T : class
    {
        this._context.Set<T>.Remove(post);
    }

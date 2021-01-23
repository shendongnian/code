    protected virtual void Merge(object modified, object attached)
    {
        if (attached != modified)
            DB.Entry(attached).CurrentValues.SetValues(modified);
        else
            DB.Entry(modified).State = EntityState.Modified;
    }

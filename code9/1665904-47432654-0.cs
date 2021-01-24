    public void RemoveItem(IEntity item)
    {
        if (Count <= 0 || item == null)
            return false;
        _entities.Remove((T)item);
    }

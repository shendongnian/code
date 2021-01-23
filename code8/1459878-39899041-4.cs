    public virtual bool IsInstanceOfType(Object o)
    {
        if (o == null)
            return false;
        // No need for transparent proxy casting check here
        // because it never returns true for a non-rutnime type.
        return IsAssignableFrom(o.GetType());
    }

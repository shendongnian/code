    public static Parent FindNode(int id, Parent current)
    {
        if (current.Id == id)
        {
            return current;
        }
        foreach (var child in current.Children)
        {
            var ret = FindNode(id, child);
            if (ret != null)
            {
                return ret;
            }
        }
        
        return null;
    }

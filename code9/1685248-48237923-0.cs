    public Tree Filter(string typeToRemove)
    {
        if (Type == typeToRemove)
            return null;
        if (Children != null)
            Children = Children.Select(c => c.Filter(typeToRemove))
                               .Where(c => c != null)
                               .ToList();
        return this;
    }

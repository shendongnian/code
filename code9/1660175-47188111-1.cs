    public void Traverse(obj)
    {
        // your logic with item
            
        foreach (var childItem in obj.Children)
        {
            Traverse(childItem);
        }
    }

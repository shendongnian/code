    public void Traverse(obj)
    {
        // your ligic wiht item
            
        foreach (var childItem in obj.Children)
        {
            Traverse(childItem);
        }
    }

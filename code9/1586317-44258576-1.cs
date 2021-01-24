    public void RemoveXCommand(object nameToRemove)
    {
        foreach(var item in pseudo)
        {
            if(item.Name == (string)nameToRemove)
            {
                pseudo.Remove(item);
            }
        }
    }

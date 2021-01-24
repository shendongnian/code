    public void Update(string name, object value)
    {
        pull(); // pull from here
        // split name into "path like"
        string[] path = name.Split('.', StringSplitOptions.RemoveEmptyEntries);
        // set current path reference
        object current = this;
        for(int i = 0; i < path.Length - 1; i++)
        {
            string way = path[i];
            // reassign reference till the pre-last element
            current = current.GetType().GetProperty(way, BindingFlags.Instance | BindingFlags.Public).GetValue(current);
        }
        // set the new value 
        current.GetType().GetProperty(path[path.Length - 1], BindingFlags.Instance | BindingFlags.Public).SetValue(current, value);
        push(); // push from here
    }

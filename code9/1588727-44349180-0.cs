    var items = new List<object>();
    var containers = new List<List<object>>();
    
    int c = 0;
    
    for (int i = 0; i < items.Count; i++)
    {
        c++; // move to next container
        // when reached to the end, insert again to first list
        if (c == containers.Count)
        {
            c = 0;
        }
        containers[c].Add(items[i]);
    }

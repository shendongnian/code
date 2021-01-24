    public int Control_list(List<int> items)
    {
        bool isEmpty = items != null ? !items.Any() : true;
        if (!isEmpty )
        {
            return items.Count;
        }
        else
        {
            return 0;
        }
    }

    public int Control_list(List<int> items = default(List<int>))
    {
        bool isEmpty = !items.Any();
        if (!isEmpty )
        {
            return items.Count;
        }
        else
        {
            return 0;
        }
    }

    private int GetObjectIndexFromTitle(string str, BindingList<ITitleAware> list)
    {
        foreach (var item in list)
        {
            if (item.Title == str)
            {
                return list.IndexOf(item);
            }
        }
        return -1;
    }

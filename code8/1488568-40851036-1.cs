    for (int i = list.Count - 1; i >= 0; i--)
    {
        var item = list[i];
        if (item.Property == 0)
        {
            list.RemoveAt(i);
        }
        else
        {
            break;
        }
    }

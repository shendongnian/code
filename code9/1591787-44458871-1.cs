    for (int i = list.Count - 1; i > -1; i--)
    {
        if (number > 10)
        {
            if (list[i] == number)
            {
                list.RemoveAt(i);
            }
        }
    }
